namespace ZDZSTORE.Validations
{
    using System.Collections;
    using System.ComponentModel.DataAnnotations;

    public class NonEmptyCollectionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is ICollection collection)
            {
                return collection.Count > 0;
            }

            return false;
        }
    }

}
