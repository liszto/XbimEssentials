// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool Xbim.CodeGeneration 
//  
//     Changes to this file may cause incorrect behaviour and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------

using Xbim.Ifc4.Interfaces;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Xbim.Ifc2x3.HVACDomain
{
	public partial class @IfcValveType : IIfcValveType
	{
		Ifc4.HvacDomain.IfcValveTypeEnum IIfcValveType.PredefinedType 
		{ 
			get
			{
				switch (PredefinedType)
				{
					case IfcValveTypeEnum.AIRRELEASE:
						return Ifc4.HvacDomain.IfcValveTypeEnum.AIRRELEASE;
					
					case IfcValveTypeEnum.ANTIVACUUM:
						return Ifc4.HvacDomain.IfcValveTypeEnum.ANTIVACUUM;
					
					case IfcValveTypeEnum.CHANGEOVER:
						return Ifc4.HvacDomain.IfcValveTypeEnum.CHANGEOVER;
					
					case IfcValveTypeEnum.CHECK:
						return Ifc4.HvacDomain.IfcValveTypeEnum.CHECK;
					
					case IfcValveTypeEnum.COMMISSIONING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.COMMISSIONING;
					
					case IfcValveTypeEnum.DIVERTING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.DIVERTING;
					
					case IfcValveTypeEnum.DRAWOFFCOCK:
						return Ifc4.HvacDomain.IfcValveTypeEnum.DRAWOFFCOCK;
					
					case IfcValveTypeEnum.DOUBLECHECK:
						return Ifc4.HvacDomain.IfcValveTypeEnum.DOUBLECHECK;
					
					case IfcValveTypeEnum.DOUBLEREGULATING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.DOUBLEREGULATING;
					
					case IfcValveTypeEnum.FAUCET:
						return Ifc4.HvacDomain.IfcValveTypeEnum.FAUCET;
					
					case IfcValveTypeEnum.FLUSHING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.FLUSHING;
					
					case IfcValveTypeEnum.GASCOCK:
						return Ifc4.HvacDomain.IfcValveTypeEnum.GASCOCK;
					
					case IfcValveTypeEnum.GASTAP:
						return Ifc4.HvacDomain.IfcValveTypeEnum.GASTAP;
					
					case IfcValveTypeEnum.ISOLATING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.ISOLATING;
					
					case IfcValveTypeEnum.MIXING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.MIXING;
					
					case IfcValveTypeEnum.PRESSUREREDUCING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.PRESSUREREDUCING;
					
					case IfcValveTypeEnum.PRESSURERELIEF:
						return Ifc4.HvacDomain.IfcValveTypeEnum.PRESSURERELIEF;
					
					case IfcValveTypeEnum.REGULATING:
						return Ifc4.HvacDomain.IfcValveTypeEnum.REGULATING;
					
					case IfcValveTypeEnum.SAFETYCUTOFF:
						return Ifc4.HvacDomain.IfcValveTypeEnum.SAFETYCUTOFF;
					
					case IfcValveTypeEnum.STEAMTRAP:
						return Ifc4.HvacDomain.IfcValveTypeEnum.STEAMTRAP;
					
					case IfcValveTypeEnum.STOPCOCK:
						return Ifc4.HvacDomain.IfcValveTypeEnum.STOPCOCK;
					
					case IfcValveTypeEnum.USERDEFINED:
						return Ifc4.HvacDomain.IfcValveTypeEnum.USERDEFINED;
					
					case IfcValveTypeEnum.NOTDEFINED:
						return Ifc4.HvacDomain.IfcValveTypeEnum.NOTDEFINED;
					
					
					default:
						throw new System.ArgumentOutOfRangeException();
				}
			} 
		}

	//## Custom code
	//##
	}
}