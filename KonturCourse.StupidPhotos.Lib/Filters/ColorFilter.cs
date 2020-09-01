using KonturCourse.StupidPhotos.Lib.Data;

namespace KonturCourse.StupidPhotos.Lib.Filters
{
    /// <summary>
    /// Базовый класс для цветовых фильтров
    /// Цветовой фильтр только изменяет цвет пикселя, не ориентируясь на окружающие пиксели
    /// </summary>
    public abstract class ColorFilter : IFilter
    {
        public Photo Process(Photo original) =>
            Photo.Create(original.Dimensions, point => TransformColor(original[point]));

        protected abstract Color TransformColor(Color color);
    }
}