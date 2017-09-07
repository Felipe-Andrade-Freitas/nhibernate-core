﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections;
using NHibernate.Cache.Access;
using NHibernate.Cache.Entry;

namespace NHibernate.Cache
{
	using System.Threading.Tasks;
	using System.Threading;
	/// <content>
	/// Contains generated async methods
	/// </content>
	public partial interface ICacheConcurrencyStrategy
	{
		/// <summary>
		/// Attempt to retrieve an object from the Cache
		/// </summary>
		/// <param name="key">The key (id) of the object to get out of the Cache.</param>
		/// <param name="txTimestamp">A timestamp prior to the transaction start time</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <returns>The cached object or <see langword="null" /></returns>
		/// <exception cref="CacheException"></exception>
		Task<object> GetAsync(CacheKey key, long txTimestamp, CancellationToken cancellationToken);

		/// <summary>
		/// Attempt to cache an object, after loading from the database
		/// </summary>
		/// <param name="key">The key (id) of the object to put in the Cache.</param>
		/// <param name="value">The value</param>
		/// <param name="txTimestamp">A timestamp prior to the transaction start time</param>
		/// <param name="version">the version number of the object we are putting</param>
		/// <param name="versionComparer">a Comparer to be used to compare version numbers</param>
		/// <param name="minimalPut">indicates that the cache should avoid a put if the item is already cached</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <returns><see langword="true" /> if the object was successfully cached</returns>
		/// <exception cref="CacheException"></exception>
		Task<bool> PutAsync(CacheKey key, object value, long txTimestamp, object version, IComparer versionComparer, bool minimalPut, CancellationToken cancellationToken);

		/// <summary>
		/// We are going to attempt to update/delete the keyed object
		/// </summary>
		/// <param name="key">The key</param>
		/// <param name="version"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <exception cref="CacheException"></exception>
		/// <remarks>This method is used by "asynchronous" concurrency strategies.</remarks>
		Task<ISoftLock> LockAsync(CacheKey key, object version, CancellationToken cancellationToken);

		/// <summary>
		/// Called after an item has become stale (before the transaction completes).
		/// </summary>
		/// <param name="key"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <exception cref="CacheException"></exception>
		/// <remarks>This method is used by "synchronous" concurrency strategies.</remarks>
		Task EvictAsync(CacheKey key, CancellationToken cancellationToken);

		/// <summary>
		/// Called after an item has been updated (before the transaction completes),
		/// instead of calling Evict().
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="currentVersion"></param>
		/// <param name="previousVersion"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <remarks>This method is used by "synchronous" concurrency strategies.</remarks>
		Task<bool> UpdateAsync(CacheKey key, object value, object currentVersion, object previousVersion, CancellationToken cancellationToken);

		/// <summary>
		/// Called when we have finished the attempted update/delete (which may or
		/// may not have been successful), after transaction completion.
		/// </summary>
		/// <param name="key">The key</param>
		/// <param name="lock">The soft lock</param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <exception cref="CacheException"></exception>
		/// <remarks>This method is used by "asynchronous" concurrency strategies.</remarks>
		Task ReleaseAsync(CacheKey key, ISoftLock @lock, CancellationToken cancellationToken);

		/// <summary>
		/// Called after an item has been updated (after the transaction completes),
		/// instead of calling Release().
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="version"></param>
		/// <param name="lock"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <remarks>This method is used by "asynchronous" concurrency strategies.</remarks>
		Task<bool> AfterUpdateAsync(CacheKey key, object value, object version, ISoftLock @lock, CancellationToken cancellationToken);

		/// <summary>
		/// Called after an item has been inserted (after the transaction completes), instead of calling release().
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		/// <param name="version"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <remarks>This method is used by "asynchronous" concurrency strategies.</remarks>
		Task<bool> AfterInsertAsync(CacheKey key, object value, object version, CancellationToken cancellationToken);

		/// <summary>
		/// Evict an item from the cache immediately (without regard for transaction isolation).
		/// </summary>
		/// <param name="key"></param>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <exception cref="CacheException"></exception>
		Task RemoveAsync(CacheKey key, CancellationToken cancellationToken);

		/// <summary>
		/// Evict all items from the cache immediately.
		/// </summary>
		/// <param name="cancellationToken">A cancellation token that can be used to cancel the work</param>
		/// <exception cref="CacheException"></exception>
		Task ClearAsync(CancellationToken cancellationToken);
	}
}