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
namespace Butter.Grammar.Internal
{
    using System.Collections.Generic;

    class EmptyFieldList :
        IFieldList
    {
        public bool HasValues => false;
        public bool HasErrors => true;
        public int Count => 0;
        public Field this[int index] => SchemaCache.MissingField;

        public bool TryGetValue(int index, out Field field)
        {
            field = SchemaCache.MissingField;
            return false;
        }

        public bool TryGetValue(string id, out Field field)
        {
            field = SchemaCache.MissingField;
            return false;
        }

        public bool Contains(Field field) => false;

        public void AddRange(IList<Field> fields)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Field field)
        {
            throw new System.NotImplementedException();
        }

        public ValidationList Validate() => throw new System.NotImplementedException();

        public void AddRange(params Field[] fields)
        {
            throw new System.NotImplementedException();
        }
    }
}