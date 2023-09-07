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

using static Apache.Arrow.Acero.CLib;

namespace Apache.Arrow.Acero
{
    public class HashJoinNodeOptions : ExecNodeOptions
    {
        private unsafe GArrowHashJoinNodeOptions* _optionsPtr;

        public unsafe HashJoinNodeOptions(GArrowJoinType joinType, string[] leftKeys, string[] rightKeys)
        {
            var leftKeysPtr = StringUtil.GetStringArrayPtr(leftKeys);
            var rightKeysPtr = StringUtil.GetStringArrayPtr(rightKeys);

            GError** error;

            _optionsPtr = garrow_hash_join_node_options_new(joinType, leftKeysPtr, (uint)leftKeys.Length, rightKeysPtr, (uint)rightKeys.Length, out error);

            ExceptionUtil.ThrowOnError(error);
        }

        internal unsafe GArrowHashJoinNodeOptions* GetPtr()
        {
            return _optionsPtr;
        }
    }
}
