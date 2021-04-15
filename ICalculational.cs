namespace Matrix_operations
{
    interface ICalculational<TReturned, T> // разное количеством входных параметров чтоб под Task подходил
    {
        TReturned Add(T term);
        TReturned Substract(T subtrahend);
        TReturned Multiply(T multiplier);
    }
}