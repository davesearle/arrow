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
    public class LiteralExpression : Expression
    {
        private IntPtr _ptr;

        public unsafe LiteralExpression(string literal)
        {
            var dataPtr = (IntPtr)StringUtil.ToCStringUtf8(literal);
            var bufferPtr = CLib.garrow_buffer_new(dataPtr, literal.Length);
            var scalarPtr = CLib.garrow_string_scalar_new(bufferPtr);
            var datumPtr = (IntPtr)CLib.garrow_scalar_datum_new((IntPtr)scalarPtr);

            _ptr = (IntPtr)CLib.garrow_literal_expression_new((GArrowDatum*)datumPtr);
        }

        public unsafe LiteralExpression(int literal)
        {
            var scalarPtr = CLib.garrow_int32_scalar_new(literal);
            var datumPtr = (IntPtr)CLib.garrow_scalar_datum_new((IntPtr)scalarPtr);

            _ptr = (IntPtr)CLib.garrow_literal_expression_new((GArrowDatum*)datumPtr);
        }

        public override IntPtr GetPtr()
        {
            return _ptr;
        }
    }
}
