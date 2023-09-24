namespace BlazorPWA2;

public static class ListExtension
{
    public static bool IsEmpty<T>(this List<T> list){
        if(list is null){
            throw new ArgumentNullException("NullReference, object not initialized");
        }

        return list.Count == 0;
    }

    public static bool IsNotEmpty<T>(this List<T> list){
         if(list is null){
            throw new ArgumentNullException("NullReference, object not initialized");
        }

        return list.Count > 0;
    }
}
