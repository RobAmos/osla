﻿using System;

namespace Growth_Curve_Software
{
    public class TestInstrument : BaseInstrumentClass
    {
        bool[] table;

        public int Current = 2;

        public TestInstrument()
        {
        }

        public bool MoveNext()
        {

            for (int i = Current + 1; i < table.Length; i++)
            {
                if (table[i])
                    if (i % Current == 0)
                    {
                        table[i] = false;
                    }
            }

            for (int i = Current + 1; i < table.Length; i++)
            {
                if (table[i])
                {
                    Current = i;
                    return true;
                }
            }
            return false;
        }

        public bool StatusOK = true;

        public override bool AttemptRecovery(InstrumentError Error)
        {
            return true;
        }

        public override bool CloseAndFreeUpResources()
        {
            StatusOK = false;
            return true;
        }

        public override void Initialize()
        {
            this.Initialize(1000);
        }

        public override void Initialize(int table_size)
        {
            table = new bool[table_size];
            for (int i = 2; i < table.Length; i++)
            {
                table[i] = true;
            }
        }
    }
}


