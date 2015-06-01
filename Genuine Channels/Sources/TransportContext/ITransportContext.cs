/* Genuine Channels product.
 * 
 * Copyright (c) 2002-2007 Dmitry Belikov. All rights reserved.
 * 
 * This source code comes under and must be used and distributed according to the Genuine Channels license agreement.
 */

using System;

using Belikov.GenuineChannels.Connection;
using Belikov.GenuineChannels.DirectExchange;
using Belikov.GenuineChannels.Logbook;
using Belikov.GenuineChannels.Parameters;
using Belikov.GenuineChannels.Receiving;
using Belikov.GenuineChannels.Security;

namespace Belikov.GenuineChannels.TransportContext
{
	/// <summary>
	/// Represents a remoting context.
	/// </summary>
	public interface ITransportContext : ISetSecuritySession
	{
		/// <summary>
		/// A set of key providers valid in this Transport Context.
		/// </summary>
		IKeyStore IKeyStore { get; }

		/// <summary>
		/// The connection manager providing transport services.
		/// </summary>
		ConnectionManager ConnectionManager { get; }

		/// <summary>
		/// The message processor that handles incoming messages.
		/// </summary>
		IIncomingStreamHandler IIncomingStreamHandler { get; }

		/// <summary>
		/// The Direct Exchange Manager (DXM).
		/// </summary>
		DirectExchangeManager DirectExchangeManager { get; }

		/// <summary>
		/// Host-specific information including URI, URL, Security Sessions and Client Sessions.
		/// </summary>
		KnownHosts KnownHosts { get; }

		/// <summary>
		/// The identifier of the current Transport Context.
		/// </summary>
		string HostIdentifier { get; }

		/// <summary>
		/// The identifier of the current Transport Context represented as a sequence of bytes.
		/// </summary>
		byte[] BinaryHostIdentifier { get; }

		/// <summary>
		/// Transport parameters that overrides default values.
		/// </summary>
		IParameterProvider IParameterProvider { get; }

		/// <summary>
		/// Gets the event provider in the Transport Context.
		/// </summary>
		IGenuineEventProvider IGenuineEventProvider { get; }

		/// <summary>
		/// Gets the logger which writes down all notices, warnings, errors and debug messages 
		/// generated by Genuine Channels.
		/// </summary>
		BinaryLogWriter BinaryLogWriter { get; set; }

		/// <summary>
		/// Security Session parameters that will be always ignored in this Transport Context.
		/// </summary>
		SecuritySessionAttributes ProhibitedSecuritySessionAttributes { get; set; }

		/// <summary>
		/// Security Session parameters that will be forced for all invocations sent in this 
		/// Transport Context if they're not prohibited by ProhibitedSecuritySessionParameters member.
		/// </summary>
		SecuritySessionAttributes ForcedSecuritySessionAttributes { get; set; }

		/// <summary>
		/// Returns an instance of the SecuritySessionParameters class brought to conformity with Transport Context settings.
		/// </summary>
		/// <param name="securitySessionParameters">Source parameters.</param>
		/// <returns>Fixed parameters.</returns>
		SecuritySessionParameters FixSecuritySessionParameters(SecuritySessionParameters securitySessionParameters);

	}
}