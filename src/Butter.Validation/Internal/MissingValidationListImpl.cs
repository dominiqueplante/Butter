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
namespace Butter.Validation.Internal
{
    using System;
    using Validation;

    class MissingValidationListImpl :
        IValidationList
    {
        public void Add(ValidationResult validation)
        {
            throw new NotImplementedException();
        }

        public bool HasErrors => false;
        public int Count => 0;

        public ValidationResult this[int index] => ValidationCache.MissingValidationResult;

        public bool TryGetValue(int index, out ValidationResult validation)
        {
            validation = ValidationCache.MissingValidationResult;
            return false;
        }

        public bool Contains(ValidationResult validation) => false;
        
        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}