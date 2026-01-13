using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyAspNetCoreMVC_CRUD.Interfaces;
using ProyAspNetCoreMVC_CRUD.Models;
using ProyAspNetCoreMVC_CRUD.Dto;

namespace ProyAspNetCoreMVC_CRUD.Controllers
{
    public class ClienteController : Controller
    {

        //creamos variable de solo lectura del dao
        private readonly IClienteDao clienteDao;
        private readonly IDistritoDao distritoDao;

        //creamos constructor
        public ClienteController(IClienteDao dao1, IDistritoDao dao2)
        {
            clienteDao = dao1;
            distritoDao = dao2;
        }

        // GET: ClienteController ------------------------------------------------------------------------
        public ActionResult IndexCliente(int nropagina = 0)
        {

            // SÍ PAGINACION
            var listado = clienteDao.ListarClientes();
            
            int filas_pagina = 5; // cantidad de filas por página
            
            int cantidad = listado.Count; // cantidad total de filas del listado
            
            int paginas = 0; // obtener el numero de página a mostrar
            
            if (cantidad % filas_pagina > 0) // si el resto sale mayor que cero, división no es exacta
                paginas = (cantidad / filas_pagina) + 1;
            else
                paginas = cantidad / filas_pagina;
            
            ViewBag.paginacion = paginas;
            
            return View(listado.Skip(nropagina * filas_pagina).Take(filas_pagina));

        } // fin index

        public ActionResult IndexClienteFiltrado(int nropagina = 0, string? cod_cli = null, string? cor_cli = null, int? cod_dist = null)
        {
            //VIEWBAGS
            ViewBag.codCli = cod_cli;
            ViewBag.corCli = cor_cli;
            ViewBag.codDist = cod_dist;
            ViewBag.distritos = new SelectList(distritoDao.ListarDistritos(), "cod_dist", "nom_dist");


            // SÍ PAGINACION
            var listado = clienteDao.ListarClientesConFiltros(cod_cli, cor_cli, cod_dist);

            int filas_pagina = 4; // cantidad de filas por página

            int cantidad = listado.Count; // cantidad total de filas del listado

            int paginas = 0; // obtener el numero de página a mostrar

            if (cantidad % filas_pagina > 0) // si el resto sale mayor que cero, división no es exacta
                paginas = (cantidad / filas_pagina) + 1;
            else
                paginas = cantidad / filas_pagina;

            ViewBag.paginacion = paginas;

            return View(listado.Skip(nropagina * filas_pagina).Take(filas_pagina));

        } // fin index listado con filtros

        // GET: ClienteController/Details/5 ------------------------------------------------------------------------
        public ActionResult DetailsCliente(string id) 
        {
            return View(clienteDao.BuscarCliente(id));

        } // fin details

        // GET: ClienteController/Create ------------------------------------------------------------------------
        public ActionResult CreateCliente()
        {
            ViewBag.distritos = new SelectList(distritoDao.ListarDistritos(), "cod_dist", "nom_dist");

            return View(new ClienteRequestDto());

        } //fin get create

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente(ClienteRequestDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = clienteDao.GrabarCliente(obj);
                    return RedirectToAction(nameof(IndexCliente));
                }
            }
            catch(Exception ex)
            {
                ViewBag.mensaje = "Error: "+ex.Message;
            }

            ViewBag.distritos = new SelectList(distritoDao.ListarDistritos(), "cod_dist", "nom_dist");
            return View(obj);

        } //fin post create

        // GET: ClienteController/Edit/5 ------------------------------------------------------------------------
        public ActionResult EditCliente(string id)
        {
            ViewBag.distritos = new SelectList(distritoDao.ListarDistritos(), "cod_dist", "nom_dist");

            var clienteResponseObtenido = clienteDao.BuscarCliente(id);

            ClienteRequestDto clienteRequest = new ClienteRequestDto
            {
                cod_cli = clienteResponseObtenido.cod_cli,
                nom_cli = clienteResponseObtenido.nom_cli,
                tel_cli = clienteResponseObtenido.tel_cli,
                cor_cli = clienteResponseObtenido.cor_cli,
                dir_cli = clienteResponseObtenido.dir_cli,
                cred_cli = clienteResponseObtenido.cred_cli,
                fec_nac = clienteResponseObtenido.fec_nac,
                cod_dist = clienteResponseObtenido.cod_dist
            };

            return View(clienteRequest);

        } //fin get edit

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCliente(string id, ClienteRequestDto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["mensaje"] = clienteDao.ActualizarCliente(obj);
                    return RedirectToAction(nameof(IndexCliente));
                }
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = "Error: " + ex.Message;
            }

            ViewBag.distritos = new SelectList(distritoDao.ListarDistritos(), "cod_dist", "nom_dist");

            return View(obj);

        } //fin post edit

        // GET: ClienteController/Delete/5 ------------------------------------------------------------------------
        public ActionResult DeleteCliente(string id)
        {
            return View(clienteDao.BuscarCliente(id));

        } //fin get delete

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCliente(string id, IFormCollection collection)
        {
            try
            {
                TempData["mensaje"] = clienteDao.DeshabilitarCliente(id);
                return RedirectToAction(nameof(IndexCliente));
            }
            catch (Exception ex)
            {
                ViewBag.mensaje = "Error: " + ex.Message;
            }

            return View();

        } //fin post delete
    }
}
