using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Errors;

public class DomainErrors
{
    public class CommonErrors
    {
        // Model Validations
        public static string IdNotValid { get; set; } = "";
        public static string NameNotValid { get; set; } = "";
        public static string ValueNotValid { get; set; } = "";
        public static string RfidIdNotValid { get; set; } = "";
        public static string UnitPriceNotValid { get; set; } = "";
        public static string VolumeNotValid { get; set; } = "";
        public static string SaleIdNotValid { get; set; } = "";
        public static string TankIdNotValid { get; set; } = "";
        public static string PasswordNotValid { get; set; } = "";
        public static string IdentityNumberNotValid { get; set; } = "";
        public static string IdentityNumberOrPasswordIncorrect { get; set; } = "";
        public static string RefreshTokenCanUseOnlyOneTime { get; set; } = "";
        public static string PlateNotValid { get; set; } = "";
        public static string StationIdNotValid { get; set; } = "";
        public static string SerialPortIdNotValid { get; set; } = "";
        public static string ConnectionStatusEnumNotValid { get; set; } = "";
        public static string TypeEnumNotValid { get; set; } = "";
        public static string DeviceIdNotValid { get; set; } = "";
        public static string StatusEnumNotValid { get; set; } = "";
    }

    public class AuthorizationErrors
    {
        // Model Validations


        // Database Validations
        public static string AuthorizationNotExist { get; set; } = "";
    }

    public class FillingPointErrors
    {
        // Model Validations
        public static string ConfirmationTypeNotValid { get; set; } = "";
        public static string RfidReaderTypeNotValid { get; set; } = "";

        // Database Validations
        public static string FillingPointNotExist { get; set; } = "";
        public static string ToDeleteThisFillingPointRemoveTheConnectedNozzles { get; set; } = "";
        public static string FillingPointIdNotValid { get; set; } = "";
        public static string FillingPointNotConnectedToTank { get; set; } = "";
        public static string FillingPointNotConnectedToPump { get; set; } = "";
        public static string FillingPointDeleted { get; set; } = "";
    }

    public class MeasurementErrors
    {
        // Model Validations

        // Database Validations
        public static string MeasurementNotExist { get; set; } = "";
    }

    public class NozzleErrors
    {
        // Model Validations 

        // Database Validations
        public static string NozzleNotExist { get; set; } = "";
    }

    public class ProductErrors
    {
        // Model Validations

        // Database Validations
        public static string ProductNotExist { get; set; } = "";
        public static string ProductIdNotValid { get; set; } = "";
        public static string ProductDeleted { get; set; } = "";
    }

    public class PumpErrors
    {
        // Model Validations
        public static string PumpIdNotValid { get; set; } = "";
        public static string PumpConnectionTypeEnumNotValid { get; set; } = "";
        public static string CounterTrackingTypeEnumNotValid { get; set; } = "";

        // Database Validations
        public static string PumpNotExist { get; set; } = "";
        public static string ToDeleteThisPumpRemoveTheConnectedFillingPoints { get; set; } = "";
        public static string PumpDeleted { get; set; } = "";
    }

    public class SaleErrors
    {
        // Model Validations
        public static string NozzleNameNotValid { get; set; } = "";
        public static string NozzleIdNotValid { get; set; } = "";
        public static string CommentNotValid { get; set; } = "";
        public static string AmountNotValid { get; set; } = "";
        public static string DiscountRatioNotValid { get; set; } = "";
        public static string DiscountNotValid { get; set; } = "";
        public static string TankRemainingFuelNotValid { get; set; } = "";
        public static string KmWorkingHourNotValid { get; set; } = "";
        public static string DatetimeStatusNotValid { get; set; } = "";
        public static string SaleTypeNotValid { get; set; } = "";
        public static string SaleStatusNotValid { get; set; } = "";
        public static string ReportStatusNotValid { get; set; } = "";
        public static string TotalCounterEndNotValid { get; set; } = "";
        public static string StartGroundTotalNotValid { get; set; } = "";
        public static string AuthorizationTypeIdNotValid { get; set; } = "";
        public static string ReceiptNoNotValid { get; set; } = "";
        public static string TankGroupNameNotValid { get; set; } = "";

        // Database Validations
        public static string SaleNotExist { get; set; } = "";
        public static string CommandTypeNotValid { get; set; } = "";
        public static string OnlyOngoingSaleCanBeClosed { get; set; } = "";
    }

    public class SerialPortErrors
    {
        // Model Validations

        // Database Validations
        public static string SerialPortNotExist { get; set; } = "";
        public static string ToDeleteThisSerialPortRemoveTheConnectedDevices { get; set; } = "";
    }

    public class StationErrors
    {
        // Model Validations
        public static string LicenseNoNotValid { get; set; } = "";
        public static string SubLicenseNoNotValid { get; set; } = "";

        // Database Validations
        public static string StationNotExist { get; set; } = "";
    }

    public class TankErrors
    {
        // Model Validations
        public static string TankCalibrationIdNotValid { get; set; } = "";

        // Database Validations
        public static string TankNotExist { get; set; } = "";
        public static string CapacityNotValid { get; set; } = "";
        public static string TankGroupIdNotValid { get; set; } = "";
        public static string TankMeasurementNotAvailable { get; set; } = "";
        public static string TankNotConnectedProduct { get; set; } = "";
        public static string TankDeleted { get; set; } = "";
    }

    public class TankCalibrationErrors
    {
        // Model Validations
        public static string VolumeCalculatedNotValid { get; set; } = "";
        public static string IterationNotValid { get; set; } = "";

        // Database Validations
        public static string TankCalibrationNotExist { get; set; } = "";
    }

    public class TankGroupErrors
    {
        // Model Validations

        // Database Validations
        public static string TankGroupNotExist { get; set; } = "";
    }

    public class TankFillingErrors
    {
        // Model Validations

        // Database Validations
        public static string TankFillingNotExist { get; set; } = "";
        public static string CanNotBeChangedAsItHasAlreadyBeenSentToDistrubitor { get; set; } = "";
        public static string CanNotBeChangedAsItHasAlreadyBeenSentToCmms { get; set; } = "";
    }

    public class UpsErrors
    {
        // Model Validations
        public static string UpsBrandNotValid { get; set; } = "";
        public static string UpsHealtyStatusNotValid { get; set; } = "";
        public static string SerialNumberNotValid { get; set; } = "";

        // Database Validations
        public static string UpsNotExist { get; set; } = "";
        public static string UpsMeasurementNotExist { get; set; } = "";
        public static string UpsIdNotValid { get; set; } = "";
    }

    public class UserErrors
    {
        // Model Validations

        // Database Validations
        public static string UserNotExist { get; set; } = "";
        public static string YourUserHaveNotSufficentPermissionToAccessThisResource { get; set; } = "";
        public static string CurrentUserHasBeenDeleted { get; set; } = "";
        public static string CurrentUserNotPermittedLoginOnThisStation { get; set; } = "";
        public static string CanNotChangeAdminPassword { get; set; } = "";
    }

    public class WaybillErrors
    {
        // Model Validations
        public static string NoNotValid { get; set; } = "";

        // Database Validations
        public static string WaybillNotExist { get; set; } = "";
    }
}
