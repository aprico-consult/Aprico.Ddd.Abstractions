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
using AutoFixture.Xunit2;

namespace Aprico.Ddd;

public abstract class EntityNotFoundExceptionFixture
{
	#region Nested Type: Throw

	[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords")]
	public class Throw : EntityNotFoundExceptionFixture
	{
		[Theory]
		[AutoData]
		public void ThrowsMessageWithId(Guid id)
		{
			Invoking(() => EntityNotFoundException.Throw<DummyEntity, Guid>(id))
				.Should()
				.Throw<EntityNotFoundException>()
				.WithMessage($"Entity 'DummyEntity {{ Id: {id:D} }}' not found.");
		}

		[Fact]
		public void ThrowsMessageWithoutId()
		{
			Invoking(static () => EntityNotFoundException.Throw<DummyEntity, Guid>())
				.Should()
				.Throw<EntityNotFoundException>()
				.WithMessage("Entity 'DummyEntity' not found.");
		}
	}

	#endregion

	#region Nested Type: ThrowIfNull

	public class ThrowIfNull : EntityNotFoundExceptionFixture
	{
		[Fact]
		public void DoesNotThrowWhenNotNull()
		{
			DummyEntity entity = new();
			Invoking(() => EntityNotFoundException.ThrowIfNull<DummyEntity, Guid>(entity))
				.Should()
				.NotThrow();
		}

		[Theory]
		[AutoData]
		[SuppressMessage("ReSharper", "NullableWarningSuppressionIsUsed")]
		public void ThrowsWhenNull(Guid id)
		{
			DummyEntity entity = null!;
			Invoking(() => EntityNotFoundException.ThrowIfNull<DummyEntity, Guid>(entity, id))
				.Should()
				.Throw<EntityNotFoundException>();
		}
	}

	#endregion

	#region Nested Type: DummyEntity

	private sealed class DummyEntity : Entity<Guid>;

	#endregion
}
