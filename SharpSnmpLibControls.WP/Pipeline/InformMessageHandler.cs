﻿// INFORM message handler class.
// Copyright (C) 2010 Lex Li
// 
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.
// 
// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using Lextm.SharpSnmpLib.Messaging;

namespace Lextm.SharpSnmpLib.Pipeline
{
    /// <summary>
    /// Message handler for INFORM.
    /// </summary>    
// ReSharper disable ClassNeverInstantiated.Global
    public class InformMessageHandler : IMessageHandler
// ReSharper restore ClassNeverInstantiated.Global
    {
        /// <summary>
        /// Handles the specified message.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="store">The object store.</param>
        /// <returns></returns>
        public void Handle(SnmpContext context, ObjectStore store)
        {
            if (store == null)
            {
                throw new ArgumentNullException("store");
            }
            
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            
            InvokeMessageReceived(new MessageReceivedEventArgs<InformRequestMessage>(context.Sender, (InformRequestMessage)context.Request, context.Binding));
            context.CopyRequest(ErrorCode.NoError, 0);
        }

        /// <summary>
        /// Occurs when a message is received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs<InformRequestMessage>> MessageReceived;

        /// <summary>
        /// Invokes the message received event handler.
        /// </summary>
        /// <param name="e">The <see cref="Lextm.SharpSnmpLib.Messaging.MessageReceivedEventArgs"/> instance containing the event data.</param>
        public void InvokeMessageReceived(MessageReceivedEventArgs<InformRequestMessage> e)
        {
            EventHandler<MessageReceivedEventArgs<InformRequestMessage>> handler = MessageReceived;
            if (handler != null) 
            {
                handler(this, e);
            }
        }
    }
}
