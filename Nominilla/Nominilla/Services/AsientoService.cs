using Nominilla.Data;
using Nominilla.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace Nominilla.Services
{
    public interface IAsientoService
    {
        Task<bool> Create(AsientoContable asientoContable);
    }
    public class AsientoService: IAsientoService
    {
        private readonly ApplicationDbContext _context;

        public AsientoService(ApplicationDbContext context)
        {
            _context = context;

        }

        public async Task<bool> Create(AsientoContable asientoContable)
        {
            var trans = asientoContable.IsCredit ? _context.RegistroTransaccions
                .Where(t => t.EmpleadoId == asientoContable.EmpleadoId
                        && t.Fecha.Date == asientoContable.FechaAsiento.Date
                        && t.TipoIngresoId.HasValue)
                : _context.RegistroTransaccions
                .Where(t => t.EmpleadoId == asientoContable.EmpleadoId
                        && t.Fecha.Date == asientoContable.FechaAsiento.Date
                        && t.TipoDeduccionId.HasValue);

            asientoContable.Monto = trans.Select(t => t.Monto).Sum();
            
            var asiento = new Asiento();
            asiento.descripcion = $"{asientoContable.Descripcion} de empleado {asientoContable.EmpleadoId}";
            asiento.idAuxiliar = 2;
            asiento.idCuentasContables = 18;
            if (asientoContable.IsCredit)
            {
                
                asiento.montoCredito = asientoContable.Monto;

            }
            else
            {
                asiento.montoDebito = asientoContable.Monto;
            }
            asiento.monto = asientoContable.Monto;
            var body = JsonSerializer.Serialize(asiento);
            body = body.Replace("ion", "ión");
            var content = new StringContent(body, System.Text.Encoding.UTF8, "application/json");
            var client = new HttpClient();
            var post = await client.PostAsync("https://sistemacontabilidad5.azurewebsites.net/api/ApiEntradaContables",
                content);
            var strRes = post.IsSuccessStatusCode ? await post.Content.ReadAsStringAsync() : "";
            var result = JsonSerializer.Deserialize<Asiento>(strRes);

            asientoContable.Cuenta = result.idCuentasContables.ToString();
            asientoContable.IdEntradaContable = asiento.idEntradaContable;
            _context.Add(asientoContable);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
