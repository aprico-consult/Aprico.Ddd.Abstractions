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

using System;
using System.Diagnostics.CodeAnalysis;
using Aprico.Ddd.Abstractions;

namespace Aprico.Ddd;

/// <summary>Represents an exception that is thrown when a specified entity cannot be found.</summary>
/// <remarks>
/// This exception is typically used in scenarios where an operation is attempted on an entity that does not exist in the
/// underlying data store or context.
/// </remarks>
[SuppressMessage("ReSharper", "MemberCanBeInternal", Justification = "Public API.")]
public class EntityNotFoundException : Exception
{
	/// <summary>Throws an <see cref="EntityNotFoundException"/> if the specified entity is null.</summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TKey">The type of the entity's key.</typeparam>
	/// <param name="entity">The entity to check for null.</param>
	/// <param name="id">The key associated with the entity.</param>
	/// <exception cref="EntityNotFoundException">
	/// Thrown when the <paramref name="entity"/> is null. If the <paramref name="id"/> is
	/// provided, the exception message will include the Id.
	/// </exception>
	[SuppressMessage("ReSharper", "MemberCanBeInternal", Justification = "Public API.")]
	public static void ThrowIfNull<TEntity, TKey>([NotNull] TEntity? entity, TKey? id = null)
		where TEntity : Entity<TKey>
		where TKey : struct
	{
		if (entity is null) Throw(entity, id);
	}

	/// <summary>Throws an <see cref="EntityNotFoundException"/> for the specified entity type.</summary>
	/// <typeparam name="TEntity">The type of the entity.</typeparam>
	/// <typeparam name="TKey">The type of the entity's key.</typeparam>
	/// <param name="_">The entity being referenced.</param>
	/// <param name="id">The key associated with the entity.</param>
	/// <exception cref="EntityNotFoundException">
	/// Always thrown to indicate that the entity of type <typeparamref name="TEntity"/>
	/// could not be found. If the <paramref name="id"/> is provided, the exception message will include the Id.
	/// </exception>
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "Public API.")]
	public static void Throw<TEntity, TKey>([NotNull] TEntity? _, TKey? id = null)
		where TEntity : Entity<TKey>
		where TKey : struct
	{
		throw id.HasValue
			? new EntityNotFoundException($"Entity '{nameof(TEntity)}' {{ {nameof(Entity<TKey>.Id)}: '{id.Value}' }} not found.")
			: new EntityNotFoundException($"Entity '{nameof(TEntity)}' not found.");
	}

	/// <summary>Initializes a new instance of the <see cref="EntityNotFoundException"/> class with default values.</summary>
	/// <remarks>Use this constructor when no specific message or inner exception needs to be provided.</remarks>
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Public API.")]
	public EntityNotFoundException() { }

	/// <summary>Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message.</summary>
	/// <param name="message">A message that describes the error.</param>
	/// <remarks>Use this constructor to provide a specific error message that gives more context about the missing entity.</remarks>
	[SuppressMessage("ReSharper", "MemberCanBePrivate.Global", Justification = "Public API.")]
	public EntityNotFoundException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message and a
	/// reference to the inner exception that caused this exception.
	/// </summary>
	/// <param name="message">A message that describes the error.</param>
	/// <param name="innerException">
	/// The exception that is the cause of the current exception, or <see langword="null"/> if no inner
	/// exception is specified.
	/// </param>
	/// <remarks>Use this constructor to capture additional details about the underlying cause of the exception.</remarks>
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Public API.")]
	public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
