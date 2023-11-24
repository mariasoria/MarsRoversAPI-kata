namespace MarsRoverKataAPI.Services;

public class Either<TError, TData>
{
    private readonly LanguageExt.Either<TError, TData> either;

    private Either(LanguageExt.Either<TError, TData> either) => this.either = either;

    public static Either<TError, TData> Right(TData data) => new(LanguageExt.Either<TError, TData>.Right(data));

    public static Either<TError, TData> Left(TError error) => new(LanguageExt.Either<TError, TData>.Left(error));

    public bool IsLeft() => either.IsLeft;

    public bool IsRight() => either.IsRight;

    public TError GetLeft() => either.LeftToList().Head();

    public TData GetRight() => either.RightToList().Head();

    public TResult Match<TResult>(Func<TData, TResult> right, Func<TError, TResult> left) => either.Match(right, left);
}