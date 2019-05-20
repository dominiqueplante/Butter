// ***********************************************************************************
// Copyright 2019 Albert L. Hives
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use
// this file except in compliance with the License. You may obtain a copy of the
// License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software distributed
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
// CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
// ***********************************************************************************
namespace Butter.Grammar
{
    using System;

    class ValidationContextImpl :
        ValidationContext
    {
        public ValidationContextImpl(Field field, ValidationResult validationResult, bool hasErrors)
        {
            Field = field;
            ValidationResult = validationResult;
            HasErrors = hasErrors;
            Timestamp = DateTimeOffset.UtcNow;
        }

        public Field Field { get; }
        public ValidationResult ValidationResult { get; }
        public bool HasErrors { get; }
        public DateTimeOffset Timestamp { get; }
    }
}