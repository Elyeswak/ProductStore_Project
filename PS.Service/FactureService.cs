﻿using PS.Data.Infrastructures;
using PS.Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Service
{
    public class FactureService : Service<Facture>, IFactureService
    {
        public FactureService(IUnitOfWork uow) : base(uow)
        {

        }

    }
}
