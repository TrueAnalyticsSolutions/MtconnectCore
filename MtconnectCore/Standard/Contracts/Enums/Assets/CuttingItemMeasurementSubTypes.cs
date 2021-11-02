﻿namespace MtconnectCore.Standard.Contracts.Enums.Assets
{
    public enum CuttingItemMeasurementSubTypes {
        /// <summary>
        /// The theoretical sharp point of the cutting tool from which the major functional dimensions are taken. 
        /// </summary>
        CUTTING_REFERENCE_POINT,
        /// <summary>
        /// The theoretical length of the cutting edge of a cutting item over sharp corners.
        /// </summary>
        CUTTING_EDGE_LENGTH,
        /// <summary>
        /// Angle between the driving mechanism locator on a tool item and the main cutting edge
        /// </summary>
        DRIVE_ANGLE,
        /// <summary>
        /// The dimension between two parallel tangents on the outside edge of a flange.
        /// </summary>
        FLANGE_DIAMETER,
        /// <summary>
        /// The distance between the cutting reference point and the rear backing surface of a turning tool or the axis of a boring bar. 
        /// </summary>
        FUNCTIONAL_WIDTH,
        /// <summary>
        /// The diameter of a circle to which all edges of a equilateral and round regular insert are tangential.
        /// </summary>
        INCRIBED_CIRCLE_DIAMETER, // Is this a typo? Should it be INSRIBED_CIRCLE_DIAMETER
        /// <summary>
        /// The angle between the major cutting edge and the same cutting edge rotated by 180 degrees about the tool axis.
        /// </summary>
        POINT_ANGLE,
        /// <summary>
        /// The angle between the tool cutting edge plane and the tool feed plane measured in a plane parallel the xy-plane. 
        /// </summary>
        TOOL_CUTTING_EDGE_ANGLE,
        /// <summary>
        /// The angle between the tool cutting edge plane and a plane perpendicular to the tool feed plane measured in a plane parallel the xy-plane. 
        /// </summary>
        TOOL_LEAD_ANGLE,
        /// <summary>
        /// The angle of the tool with respect to the workpiece for a given process. The value is application specific. 
        /// </summary>
        TOOL_ORIENTATION,
        /// <summary>
        /// The measure of the length of a wiper edge of a cutting item.
        /// </summary>
        WIPER_EDGE_LENGTH,
        /// <summary>
        /// The length of a portion of a stepped tool that is related to a corresponding cutting diameter measured from the cutting reference point of that cutting diameter to the point on the next cutting edge at which the diameter starts to change. 
        /// </summary>
        STEP_DIAMETER_LENGTH,
        /// <summary>
        /// The angle between a major edge on a step of a stepped tool and the same cutting edge rotated 180 degrees about its tool axis. 
        /// </summary>
        STEP_INCLUDED_ANGLE,
        /// <summary>
        /// The nominal radius of a rounded corner measured in the XY-plane. 
        /// </summary>
        CUTTING_DIAMETER,
        /// <summary>
        /// The nominal radius of a rounded corner measured in the XY-plane. 
        /// </summary>
        CUTTING_HEIGHT,
        /// <summary>
        /// The nominal radius of a rounded corner measured in the X Y-plane.
        /// </summary>
        CORNER_RADIUS,
        /// <summary>
        /// The total weight of the cutting tool in grams. The force exerted by the mass of the cutting tool. 
        /// </summary>
        WEIGHT,
        /// <summary>
        /// The distance from the gauge plane or from the end of the shank of the cutting tool, if a gauge plane does not exist, to the cutting reference point determined by the main function of the tool. This measurement will be with reference to the Cutting Tool and MUST NOT exist without a cutting tool. 
        /// </summary>
        FUNCTIONAL_LENGTH,
        /// <summary>
        /// The flat length of a chamfer.
        /// </summary>
        CHAMFER_FLAT_LENGTH,
        /// <summary>
        /// The width of the chamfer.
        /// </summary>
        CHAMFER_WIDTH,
        /// <summary>
        /// W1 is used for the insert width when an inscribed circle diameter is not practical.
        /// </summary>
        INSERT_WIDTH
    }
}