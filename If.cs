using System.Linq.Expressions;
public static class QueryableExtensions
{
	public static IQueryable<TSource> If<TSource>(this IQueryable<TSource> source, bool condition, Func<IQueryable<TSource>, IQueryable<TSource>> queryable)
	{
		return condition ? queryable(source) : source;
	}
}