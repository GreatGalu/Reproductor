using System;
using System.Collections;
using System.Collections.Generic;

namespace SoundCore.EstructurasPropias
{
    public class ListaSimpleEnlazada<T> : IEnumerable<T>
    {
        public Nodo<T>? Cabeza { get; private set; }
        public int Conteo { get; private set; }

        public bool EstaVacia => Cabeza == null;

        public void AgregarAlFinal(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);
            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                var actual = Cabeza!;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            Conteo++;
        }

        public void ReproducirSiguiente(T valor)
        {
            var nuevoNodo = new Nodo<T>(valor);
            if (EstaVacia)
            {
                Cabeza = nuevoNodo;
            }
            else
            {
                nuevoNodo.Siguiente = Cabeza!.Siguiente;
                Cabeza.Siguiente = nuevoNodo;
            }
            Conteo++;
        }

        public T AvanzarPista()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La cola de reproducción está vacía.");

            T valor = Cabeza!.Valor;
            Cabeza = Cabeza.Siguiente;
            Conteo--;
            return valor;
        }

        public void Invertir()
        {
            Nodo<T>? previo = null;
            Nodo<T>? actual = Cabeza;
            Nodo<T>? siguiente = null;

            while (actual != null)
            {
                siguiente = actual.Siguiente;
                actual.Siguiente = previo;
                previo = actual;
                actual = siguiente;
            }

            Cabeza = previo;
        }

        public void InsertarOrdenado(T valor, Comparison<T> comparador)
        {
            var nuevo = new Nodo<T>(valor);

            if (EstaVacia || comparador(valor, Cabeza!.Valor) < 0)
            {
                nuevo.Siguiente = Cabeza;
                Cabeza = nuevo;
                Conteo++;
                return;
            }

            var actual = Cabeza;
            while (actual.Siguiente != null && comparador(valor, actual.Siguiente.Valor) >= 0)
            {
                actual = actual.Siguiente;
            }

            nuevo.Siguiente = actual.Siguiente;
            actual.Siguiente = nuevo;
            Conteo++;
        }

        public void DepurarDuplicados(Func<T, T, bool> sonIguales)
        {
            var actual = Cabeza;

            while (actual != null)
            {
                var corredor = actual;
                while (corredor.Siguiente != null)
                {
                    if (sonIguales(actual.Valor, corredor.Siguiente.Valor))
                    {
                        corredor.Siguiente = corredor.Siguiente.Siguiente;
                        Conteo--;
                    }
                    else
                    {
                        corredor = corredor.Siguiente;
                    }
                }
                actual = actual.Siguiente;
            }
        }

        public void Limpiar()
        {
            Cabeza = null;
            Conteo = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var actual = Cabeza;
            while (actual != null)
            {
                yield return actual.Valor;
                actual = actual.Siguiente;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
