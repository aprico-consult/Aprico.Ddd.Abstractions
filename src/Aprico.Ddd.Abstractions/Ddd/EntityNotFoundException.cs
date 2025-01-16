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

namespace Aprico.Ddd;

/// <summary>Represents an exception that is thrown when a specified entity cannot be found.</summary>
/// <remarks>
/// This exception is typically used in scenarios where an operation is attempted on an entity that does not exist in the
/// underlying data store or context.
/// </remarks>
[SuppressMessage("ReSharper", "UnusedType.Global", Justification = "Public API.")]
public class EntityNotFoundException : Exception
{
	/// <summary>Initializes a new instance of the <see cref="EntityNotFoundException"/> class with default values.</summary>
	/// <remarks>Use this constructor when no specific message or inner exception needs to be provided.</remarks>
	public EntityNotFoundException() { }

	/// <summary>Initializes a new instance of the <see cref="EntityNotFoundException"/> class with a specified error message.</summary>
	/// <param name="message">A message that describes the error.</param>
	/// <remarks>Use this constructor to provide a specific error message that gives more context about the missing entity.</remarks>
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
	public EntityNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
