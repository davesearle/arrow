﻿// Licensed to the Apache Software Foundation (ASF) under one or more
// contributor license agreements. See the NOTICE file distributed with
// this work for additional information regarding copyright ownership.
// The ASF licenses this file to You under the Apache License, Version 2.0
// (the "License"); you may not use this file except in compliance with
// the License.  You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using static Apache.Arrow.Acero.CLib;

namespace Apache.Arrow.Acero
{
    public class FieldExpression : Expression
    {
        private IntPtr _ptr;

        public unsafe FieldExpression(string field)
        {
            var reference = (nint)StringUtil.ToCStringUtf8(field);

            GError** error;

            _ptr = (IntPtr)CLib.garrow_field_expression_new(reference, out error);

            ExceptionUtil.ThrowOnError(error);
        }

        public override IntPtr GetPtr()
        {
            return _ptr;
        }
    }
}
