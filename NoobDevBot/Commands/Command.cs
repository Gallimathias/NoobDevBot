﻿using NoobDevBot.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace NoobDevBot.Commands
{
    public abstract class Command<TParameter, TOut> : ICommand<TParameter, TOut>
    {
        public Func<TParameter, TOut> NextFunction { get; set; }

        public bool Finished { get; protected set; }

        public event FinishEventHandler<TParameter> FinishEvent;

        public TOut Dispatch(TParameter parameter) => NextFunction(parameter);
       
        public void RaiseFinishEvent(object sender, TParameter e) => FinishEvent?.Invoke(sender, e);

    }
}
