#region region Copyright & License

// Copyright © 2024 - 2025 Aprico Consultants
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Aprico.Ddd.Abstractions;

public interface IReadOnlyRepository<TEntity, in TKey> : INonQueryableReadOnlyRepository<TEntity, TKey>
	where TEntity : AggregateRoot<TKey>
	where TKey : struct
{
	/// <summary>Creates an object that can be used to query the repository using LINQ.</summary>
	/// <returns>An object that can be used to write LINQ queries. Supported features are LINQ-provider dependent.</returns>
	/// <example>
	/// <code>
	/// // eagerly load (as opposed to lazy load) the order lines with the order objects
	/// var query = orderRepository.CreateQuery(o => o.OrderLines);
	/// </code>
	/// </example>
	IQueryable<TEntity> CreateQuery();

	/// <summary>Finds all entities.</summary>
	/// <param name="cancellationToken"></param>
	/// <returns>An enumeration containing all entities.</returns>
	Task<IEnumerable<TEntity?>> FindAllAsync(CancellationToken cancellationToken = default);
}
