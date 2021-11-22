namespace SimbirsoftWorkshop.WebApi.Models
{
    public class PersonBookAuthorDto
    {
        /// <summary>
        /// Идентификатор автора книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя автора
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия автора
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Отчество автора
        /// </summary>
        public string MiddleName { get; set; }
    }
}
