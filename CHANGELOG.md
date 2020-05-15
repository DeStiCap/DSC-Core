## [0.2.0-preview.1] - 2019-05-15

## [0.1.11-preview.2] - 2019-03-18
- Add DPad button to InputButtonType enum.
- Change InputUtility ConvertRawValueToGetType function parameter raw bool instead raw float.

## [0.1.10-preview.1] - 2019-02-28
- Add DirectionType enum.
- Add DirectionType2D enum.
- Add InputButtonType enum.

## [0.1.9-preview.1] - 2019-02-23
- Move ChangeUnityTimeScale method from manager to DSC_Time.

## [0.1.8-preview.4] - 2019-02-19
- Add GetRandom extension method for array and list.
- Add RemoveAllNull extension method for list.
- Add DSC_Time singleton for use in game instead normal time. (For change game speed.)
- Add IUpdate for use to update object itself.
- Add BaseUpdateMono that has IUpdate interface.
- Add IUpdate extension for update all object in array and list.
- Change BasePoolingManager name to DSC_Pooling.
- Global_TimeManager now derievd from DSC_Time.
- Global_TimeManager now show time scale on inspector.

## [0.1.7-preview.1] - 2019-02-17
- Improve InputUtility method to support change from New Version of New Input System.

## [0.1.6-preview.1] - 2019-02-16
- Add Pooling Manager for pooling class object.
- Add IPoolable interface for use with Pooling Manager.

## [0.1.5-preview.1] - 2019-02-15
- Add more extension method try get data to array and list.

## [0.1.4-preview.2] - 2019-02-10
- Add TryParse Enum to FlagUtility for try parse generic flag to enum.
- Add Time Manager to manager template.

## [0.1.3-preview.1] - 2019-02-09
- Add SizeOf method to FlagUtility for check generic flag size.
- Add TryParse Byte,Short,Int,Long to FlagUtility for try parse value from generic flag.

## [0.1.2-preview.1] - 2019-02-08
- Add Array extension Contains method.
- Add GameObject extension CompareTag, Now it can check array string.

## [0.1.1-preview.3] - 2019-02-07
- Add game manager template.
- Add multiple attribute system.
- Add label name attribute.
- Add tag field attribute.
- Now all custom attribute support multiple attribute.

## [0.1.0-preview.1] - 2019-02-06
- Add read only field attribute.

## [0.0.9-preview.3] - 2019-01-30
- Add EventString that derived class from UnityEvent<string>.
- Add EventInt that derived class from UnityEvent<int>.
- Add EventFloat that derived class from UnityEvent<float>.
- Add EventBool that derived class from UnityEvent<bool>.
- Add EventUnityEvent that derived class from UnityEvent<UnityEvent>.
- Add extension array method TryGetData.
- Add extension array method HasData.
- Add extension list method TryGetData.
- Add extension list method HasData.

## [0.0.8-preview.1] - 2019-01-29
- Add scriptable script template.

## [0.0.7-preview.2] - 2019-01-28
- Add manager script template.

## [0.0.6-preview.3] - 2019-01-26
- Add mono script template.
- Add GameObjectEvent that derived from UnityEvent<GameObject>. It will remove in Unity 2020.

## [0.0.5-preview.1] - 2019-01-25
- Add Check all flag in FlagUtility.

## [0.0.4-preview.5] - 2019-01-23
- Add convert to get input type method to InputUtility for helper convert float from new input to get input type.
- Add update type.

## [0.0.3-preview.1] - 2019-01-22
- Add calculate axis for use new input same as old input get axis.

## [0.0.2-preview.1] - 2019-01-21
- Add enum input get key type.

## [0.0.1-preview.1] - 2019-12-23
- Add Base Component Controller.
- Add Base Group Component Controller.

## [0.0.0-preview.3] - 2019-12-17
- Add color html attribute.
- Add enum mask attribute.
- Add FlagUtility.