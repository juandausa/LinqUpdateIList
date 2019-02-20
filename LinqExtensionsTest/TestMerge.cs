using Entidades;
using LinqExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LinqExtensionsTest
{
    [TestClass]
    public class TestMerge
    {
        [TestMethod]
        public void TestMergeDosIListVacias_DevuelveIListVacia()
        {
            IList<Identidad> listaOriginal = new List<Identidad>();
            IList<Identidad> listaActualizada = new List<Identidad>();
            Assert.AreEqual(0, listaOriginal.Actualizar(listaActualizada).Count);
        }

        [TestMethod]
        public void TestMergeIListOriginalVaciaNuevaListaConElementos_DevuelveIListConElementos()
        {
            IList<Identidad> listaOriginal = new List<Identidad>();
            IList<Identidad> listaActualizada = new List<Identidad>() { new Identidad(1), new Identidad(5) };
            Assert.AreEqual(2, listaOriginal.Actualizar(listaActualizada).Count);
            Assert.AreEqual(1, listaOriginal[0].Id);
            Assert.AreEqual(5, listaOriginal[1].Id);
        }

        [TestMethod]
        public void TestMergeIListOriginalConElementosSinIdentidadListaActualizadaConElementosSinIdentidad_DevuelveIListConTodosLosElementos()
        {
            IList<Identidad> listaOriginal = new List<Identidad>() { new Identidad(0), new Identidad(0) };
            IList<Identidad> listaActualizada = new List<Identidad>() { new Identidad(0), new Identidad(0) };
            Assert.AreEqual(4, listaOriginal.Actualizar(listaActualizada).Count);
        }

        [TestMethod]
        public void TestMergeIListOriginalConElementosNuevaListaConMenosElementos_DevuelveIListConMenosElementos()
        {
            IList<Identidad> listaOriginal = new List<Identidad>() { new Identidad(1), new Identidad(5), new Identidad(45), new Identidad(85) };
            IList<Identidad> listaActualizada = new List<Identidad>() { new Identidad(1), new Identidad(45) };
            Assert.AreEqual(2, listaOriginal.Actualizar(listaActualizada).Count);
            Assert.AreEqual(1, listaOriginal[0].Id);
            Assert.AreEqual(45, listaOriginal[1].Id);
        }
    }
}
