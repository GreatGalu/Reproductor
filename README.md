# 🎧 SoundCore Engine GUI — Autoevaluación

**Proyecto Integral Unidad 2:** DJ Queue & Transition Manager
**Institución:** TecNM Campus Monclova — Ingeniería en Informática
**Asignatura:** Estructura de Datos (3er Semestre) — Unidad 1
**Integrante(s):**  Heladio Gutierrez Aleman
**Fecha / Versión:** _[29/09/2026]_ — v2.0

---

## 1. Resumen del proyecto

Reproductor de audio en Windows Forms (.NET) con una cola de reproducción manejada por tres estructuras intercambiables desde la interfaz:

- `ListaSimpleEnlazada<T>` y `Nodo<T>` (implementación propia, sin arrays internos).
- `System.Collections.Generic.LinkedList<T>`.
- `System.Collections.Generic.List<T>`.

Además de lo pedido, el reproductor reproduce archivos `.mp3` y `.wav` (NAudio), lee metadatos y carátula (TagLibSharp), y tiene control de posición, volumen, play, pausa y stop.

El módulo de benchmark compara las tres estructuras con `Stopwatch` (25,000 inserciones intermedias). Sus resultados se muestran en un **panel dentro del propio reproductor** (`txtResultadosBenchmark`) y se ejecutan en segundo plano para no congelar la ventana.

---

## 2. Autoevaluación por rúbrica

| Dimensión | Peso | Mi nota | Nivel | Aporte |
|---|---|---|---|---|
| Estructuras desde cero | 40% | 96 | Excelente | 38.4 |
| Integración .NET | 20% | 88 | Notable | 17.6 |
| Interfaz gráfica WinForms | 25% | 82 | Notable | 20.5 |
| Benchmark y análisis | 15% | 95 | Excelente | 14.3 |
| **Calificación final** | **100%** | **≈ 91** | **Notable (alto)** | **90.8** |

### 2.1 Estructuras desde cero (40%) — 96/100

**A favor**
- Implementé los 6 métodos: `AgregarAlFinal`, `ReproducirSiguiente`, `AvanzarPista`, `Invertir`, `InsertarOrdenado` y `DepurarDuplicados`, más `Limpiar` y el enumerador.
- `Invertir()` es estrictamente in-place: solo redirige `Siguiente` usando las tres referencias `previo`, `actual` y `siguiente`, sin listas auxiliares.
- No uso arrays, `List<T>` ni bibliotecas auxiliares dentro de la clase.
- `DepurarDuplicados` conserva la primera aparición, descuenta `Conteo` y no rompe los enlaces.

**En contra**
- En la GUI, "Ordenar BPM" con la lista propia reconstruye la lista mediante una lista temporal (`InsertarOrdenado` nodo por nodo y luego `AgregarAlFinal`). Funciona, pero no es in-place y su costo total es O(n²).
- `AgregarAlFinal` es O(n) porque no mantiene puntero a la cola (el ReadMe lo permite).

### 2.2 Integración .NET (20%) — 88/100

**A favor**
- Uso `LinkedList<T>` con `AddLast`, `AddFirst`, `AddAfter` y `RemoveFirst`, y `List<T>` con `Add`, `Insert`, `RemoveAt`, `Reverse` y `Sort`.
- El cambio de estructura desde los `RadioButton` opera siempre sobre la colección seleccionada.

**En contra**
- Con `LinkedList<T>`, invertir, ordenar y purgar pasan por una lista temporal o por LINQ (`OrderBy`, `GroupBy`) y luego se reconstruye la lista. Son conversiones redundantes.

### 2.3 Interfaz gráfica WinForms (25%) — 82/100

**A favor**
- La vista (`dgvCola`) se refresca en vivo al cambiar de estructura.
- Si la cola está vacía, "Avanzar" muestra un `MessageBox` controlado (CP-07) sin caerse.
- Los campos vacíos tienen valores por defecto (título, artista, BPM y duración).
- El benchmark corre en segundo plano y desactiva su botón mientras trabaja.
- Extras: reproducción real de audio, carátula, barra de progreso y volumen.

**En contra**
- Uso `TextBox` (`txtBpm`, `txtDuracion`) en vez de `NumericUpDown` (`numBpm`, `numDuracion`), así que no se valida el rango 60–220.
- Faltan `lblNowPlaying` y `lblEstadisticas`, que pide el ReadMe (pista en curso y total de pistas con duración acumulada).
- `txtTitulo` y `txtArtista` sirven a la vez para capturar y para filtrar el grid, lo que puede confundir.
- El grid no muestra la referencia del nodo (`Nodo -> Next`) del mockup.

### 2.4 Benchmark y análisis (15%) — 95/100

**A favor**
- Mido con `Stopwatch` las tres estructuras, con la misma operación (inserción intermedia) y 25,000 elementos.
- Los resultados y la conclusión técnica salen en el panel del reproductor (`txtResultadosBenchmark`).
- La conclusión explica la diferencia O(1) contra O(n) y el efecto de `Array.Copy` y del redimensionamiento del búfer en `List<T>`.

**En contra**
- Solo mido inserción intermedia (no inversión, ordenamiento ni purga) y hago una sola corrida, sin promediar.
- Con 25,000 elementos y referencias pequeñas, `List<T>.Insert` puede seguir siendo rápida. La diferencia crece con más elementos.

---

## 3. Casos de prueba formales

| ID | Escenario | Estado |
|---|---|---|
| CP-01 | Inserción al final | ✅ Funciona |
| CP-02 | Up Next (fila 2) | ✅ Funciona |
| CP-03 | Avanzar pista | ⚠️ Desencola y reproduce la nueva cabeza, pero no hay `lblNowPlaying` |
| CP-04 | Inversión in-place | ✅ Funciona |
| CP-05 | Ordenar por BPM | ✅ Funciona |
| CP-06 | Purgar duplicados | ✅ Funciona |
| CP-07 | Excepción con cola vacía | ✅ Funciona (`MessageBox` controlado) |

---

## 4. Pendientes antes de la entrega

- [ ] Cambiar `txtBpm` y `txtDuracion` por `NumericUpDown` (`numBpm` con rango 60–220 y `numDuracion`).
- [ ] Agregar `lblNowPlaying` y `lblEstadisticas`.
- [ ] Agregar en cada archivo `.cs` el comentario de cabecera con nombres, números de control, fecha y versión.
- [ ] Subir la solución `.sln` completa al repositorio Git.
- [ ] Grabar el video de máximo 3 minutos:
  - 0:00–1:15 operaciones de la cola
  - 1:15–2:00 benchmark con 20,000+ elementos
  - 2:00–3:00 explicación de `Invertir()`
- [ ] Justificar en la entrega el uso de NAudio y TagLibSharp, ya que el ReadMe original pide ninguna librería externa obligatoria.

---

## 5. Conclusión

Me califico con **≈ 91/100**. Mi fortaleza es la lista enlazada propia, con `Invertir()` in-place y el benchmark que sustenta la diferencia entre O(1) y O(n). Mi área de mejora es la interfaz: faltan controles del ReadMe y validación de campos numéricos. Si corrijo los pendientes de la sección 4, la nota de interfaz sube y la calificación final se acerca a 95.
