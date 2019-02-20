using Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LinqExtensions
{
    public static class ListExtensions
    {
        public static IList<T> Actualizar<T>(this IList<T> original, IList<T> actualizada) where T : Identidad
        {
            RemoverElementos(original, actualizada);
            ActualizarElementos(original, actualizada);
            AgregarElementos(original, actualizada);

            return original;
        }

        private static void RemoverElementos<T>(IList<T> original, IList<T> actualizada) where T : Identidad
        {
            var elementosARemover = original.Where(elementoOriginal => !actualizada.Any(elementoNuevo => elementoOriginal.Id == elementoNuevo.Id)).ToList();
            // var elementosARemover = original.Where(elementoOriginal => !actualizada.Any(elementoNuevo => elementoOriginal.Id == elementoNuevo.Id));
            foreach (var elementoARemover in elementosARemover)
            {
                original.Remove(elementoARemover);
            }
        }

        private static void AgregarElementos<T>(IList<T> original, IList<T> actualizada) where T : Identidad
        {
            var elementosAAgregar = actualizada.Where(elementoNuevo => !original.Any(elementoOriginal => elementoOriginal.Id == elementoNuevo.Id) || elementoNuevo.Id == 0);
            foreach (var nuevoElemento in elementosAAgregar)
            {
                original.Add(nuevoElemento);
            }
        }

        private static void ActualizarElementos<T>(IList<T> original, IList<T> actualizada) where T : Identidad
        {
            var elementosAActualizar = actualizada.Where(elementoNuevo => elementoNuevo.Id != 0 && !original.Any(elementoOriginal => elementoOriginal.Id == elementoNuevo.Id));
            foreach (var elementoAActualizar in elementosAActualizar)
            {
                // Actualizar Elemento
            }
        }
    }
}
