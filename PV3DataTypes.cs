using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV3TestUtility4
{
  class PV3DataTypes
  {
    public enum PV3CommandType
    {
      READ_VERSION = 0x00,
      BOOTLOAD = 0x10, //Enter bootloader mode

      ID_BOARD = 0x31,
      UPDATE_LED = 0x32,
      SET_TEMP_REAL = 0x33,
      RD_TEMP = 0x34,
      SET_TEMP_LOGGING = 0x35,
      RD_TEMP_LOGGING = 0x36,
      RD_POT = 0x37,

      TOGGLE_LEDS = 0x80,
      RD_SW2 = 0x81,
      TOGGLE_BLINKSTATUS = 0x82, //Toggle USB status indication via LED on/off

      START_DATA_ACQ = 0xA0, //Start acquisition of data
      STOP_DATA_ACQ = 0xA1, //Stop acquisition of data
      RD_DATA_EEPROM_CHECKSUM = 0xA2, //Return sum of DATA EEPROM contents
      RD_FIRMWARE_VERSION = 0xA3, //Return firmware version
      RD_HARDWARE_VERSION = 0xA4, //Return hardware version
      SET_HARDWARE_VERSION = 0xA5, //Set hardware version

      RD_LSSDP = 0xEB, //Read low speed sensor data packet
      SET_LUNG_SN = 0xEC, //Write SNPkt to TTL (PC to TTL)
      RD_LUNG_SN = 0xED, //Read SNPkt from TTL (TTL to PC)
      SET_LUNG_MODEL = 0xEE, //Write LungModel to TTL (PC to TTL)
      RD_LUNG_MODEL = 0xEF, //Read LungModel from TTL (TTL to PC)

      SET_CH0_GAIN = 0xF0, //Set CH0 gain
      SET_CH1_GAIN = 0xF1, //Set CH1 gain
      SET_CH2_GAIN = 0xF2, //Set CH2 gain
      SET_CH3_GAIN = 0xF3, //Set CH3 gain
      SET_CH4_GAIN = 0xF4, //Set CH4 gain
      SET_ZEROS = 0xF5, //Set zero offset values for high speed sensor channels
      RD_HSSCD = 0xF6, //Read high speed sensor calibration data
      SET_RLTO = 0xF7, //Set right lung temperature sensor offset
      SET_RLTG = 0xF8, //Set right lung temperature sensor gain
      SET_LLTO = 0xF9, //Set left lung emperature sensor offset
      SET_LLTG = 0xFA, //Set left lung temperature sensor gain
      SET_O2O = 0xFB, //Set O2 sensor offset
      SET_O2G = 0xFC, //Set O2 sensor gain
      RD_LSSCD = 0xFD, //Read low speed sensor calibration data
      RD_HSSDP = 0xFE, //Read High speed sensor data packet
      RESET = 0xFF,

      RESET_FROM_BOOTLOADER = 0x08 //Reset MCU from the Microchip HID Bootloader firmware
    }

    public byte ttlModel = 0;                              //Flag indicating the TTL model attached
    public byte[] ttlSN = new byte[2];                     //Byte array for the serial number of the TTL attached

    public ushort PPROXZero = 953;
    public ushort PLEFTZero = 953;
    public ushort PRGHTZero = 953;
    public ushort PHIGHZero = 150;
    public ushort AUXINZero = 815;

    public ushort PPROXGain = 45435;
    public ushort PLEFTGain = 45435;
    public ushort PRGHTGain = 45435;
    public ushort PHIGHGain = 27081;
    public ushort AUXINGain = 1;

    public ushort PPROXRaw;
    public ushort PLEFTRaw;
    public ushort PRGHTRaw;
    public ushort PHIGHRaw;
    public ushort AUXINRaw;

    // The following are probably in reverse order; Actual coefficients used are read from the test lung once the USB connection is established:
    public double[] ccLeft = new double[] { 0.000811874809, -0.074691255175, 2.301089012738, 27.441272849990 };
    public double[] ccRight = new double[] { 0.000811874809, -0.074691255175, 2.301089012738, 27.441272849990 };

    // Airway pressure drop versus flow rate correlation coefficients (using coefficients for the A/I model lung with Rp20 resistor for defaukt values)
    private double[] leftAWCoefs = new double[]
    {
      0.0,
      0.0,
      0.0,
      0.0
    };

    private double[] rightAWCoefs = new double[]
    {
      -0.000217916079811409,
      0.0191872307209381,
      -0.591471116586059,
      9.06706159376937
    };

    private readonly double[] zeroAWCoefs = new double[]
    {
      0.0,
      0.0,
      0.0,
      0.0
    };

    private readonly double[] awFCSLRp5 = new double[]
    {
      -0.011108739,
      0.386956116,
      -4.741817378,
      29.42858549
    };

    private readonly double[] awFCSLRp20 = new double[]
    {
      -0.000215128,
      0.019294681,
      -0.601892372,
      9.160610011
    }; 
    
    private readonly double[] awFCSLRp50 = new double[]
    {
      -2.89477E-06,
      0.000685456,
      -0.056336279,
      2.271806034
    };

    private readonly double[] awFCAIRp5 = new double[]
    {
      -0.011585568,
      0.395408849,
      -4.755915912,
      29.2937848
    };

    private readonly double[] awFCAIRp20 = new double[]
    {
      -0.000217916,
      0.019187231,
      -0.591471117,
      9.067061594
    };

    private readonly double[] awFCAIRp50 = new double[]
    {
      -2.93737E-06,
      0.000691326,
      -0.056574759,
      2.279627536
    };

    private readonly double[] awFCDARp5 = new double[]
    {
      -0.006401364,
      0.234741479,
      -3.179188791,
      24.4329498
    };

    private readonly double[] awFCDARp20 = new double[]
    {
      -0.000203878,
      0.017976849,
      -0.558611697,
      8.79453692
    };

    private readonly double[] awFCDARp50 = new double[]
    {
      -2.86709E-06,
      0.00067353,
      -0.05514947,
      2.242558137
    };

    private const long maxSampleCount = 10000;
    public static long MaxSampleCount => maxSampleCount;

    private const int sampleRate = 500;
    public static int SampleRate => sampleRate;

    private const ushort pressureStreamSmoothingSampleCount = 7;

    private long lastSampleNumber = 0;
    private long sampleCount = 0;

    public double[] airwayPressureStream = new double[maxSampleCount];
    public double[] leftLungPressureStream = new double[maxSampleCount];
    public double[] rightLungPressureStream = new double[maxSampleCount];
    public double[] volumeStream = new double[maxSampleCount];
    public double[] leftVolumeStream = new double[maxSampleCount];
    public double[] rightVolumeStream = new double[maxSampleCount];
    public double[] flowStream = new double[maxSampleCount];
    public double[] leftFlowStream = new double[maxSampleCount];
    public double[] rightFlowStream = new double[maxSampleCount];

    private double pprox;

    public double PPROX
    {
      get
      {
        pprox = (PPROXRaw - PPROXZero) * PPROXGain / 1000000.0;
        return pprox;
      }
      set { pprox = value; }
    }

    private double pleft;

    public double PLEFT
    {
      get
      {
        pleft = (PLEFTRaw - PLEFTZero) * PLEFTGain / 1000000.0;
        return pleft;
      }
      set { pleft = value; }
    }

    private double prght;

    public double PRGHT
    {
      get
      {
        prght = (PRGHTRaw - PRGHTZero) * PRGHTGain / 1000000.0;
        return prght;
      }
      set { prght = value; }
    }

    /// <summary>
    /// Helper function to calculate left volume
    /// </summary>
    private double CalculateLeftVolume(double lungPressure)
    {
      return Math.Pow(lungPressure, 4) * ccLeft[3] + Math.Pow(lungPressure, 3) * ccLeft[2] + Math.Pow(lungPressure, 1) * ccLeft[1] + lungPressure * ccLeft[0];
    }
    private double vleft;
    public double VLEFT
    {
      get
      {
        vleft = CalculateLeftVolume(pleft);
        return vleft;
      }
      set { vleft = value; }
    }

    /// <summary>
    /// Helper function to calculate right volume
    /// </summary>
    private double CalculateRightVolume(double lungPressure)
    {
      return Math.Pow(lungPressure, 4) * ccRight[3] + Math.Pow(lungPressure, 3) * ccRight[2] + Math.Pow(lungPressure, 2) * ccRight[1] + lungPressure * ccRight[0];
    }
    private double vrght;
    public double VRIGHT
    {
      get
      {
        vrght = CalculateRightVolume(prght);
        return vrght;
      }
      set { vrght = value; }
    }

    private double CalculateLeftAirwayFlow(double deltaP)
    {
      return Math.Pow(deltaP, 4) * leftAWCoefs[0] + Math.Pow(deltaP, 3) * leftAWCoefs[1] + Math.Pow(deltaP, 2) * leftAWCoefs[2] + deltaP * leftAWCoefs[3];
    }
    private double fawleft; // Flow through left airway, calculated using airway characteristic correlation functions
    public double FAWLEFT
    {
      get
      {
        fawleft = CalculateLeftAirwayFlow(pprox - pleft);
        return fawleft;
      }
      set { fawleft = value; }
    }

    private double CalculateRightAirwayFlow(double deltaP)
    {
      return Math.Pow(deltaP, 4) * rightAWCoefs[0] + Math.Pow(deltaP, 3) * rightAWCoefs[1] + Math.Pow(deltaP, 2) * rightAWCoefs[2] + deltaP * rightAWCoefs[3];
    }
    private double fawright; // Flow through right airway, calculated using airway characteristic correlation functions
    public double FAWRIGHT
    {
      get
      {
        fawright = CalculateRightAirwayFlow(pprox - prght);
        return fawright;
      }
      set { fawright = value; }
    }

    private double phigh;

    public double PHIGH
    {
      get
      {
        phigh = (PHIGHRaw - PHIGHZero) * PHIGHGain / 1000000.0;
        return phigh;
      }
      set { phigh = value; }
    }

    private double auxin;

    public double AUXIN
    {
      get
      {
        auxin = (AUXINRaw - AUXINZero) * AUXINGain / 1000000.0;
        return auxin;
      }
      set { auxin = value; }
    }

    public ushort FiO2Zero = 5;
    public ushort TLEFTZero = 0;
    public ushort TRGHTZero = 0;

    public ushort FiO2Gain = 2394;
    public ushort TLEFTGain = 1;
    public ushort TRGHTGain = 1;

    public ushort FiO2Raw;
    public ushort TLEFTRaw;
    public ushort TRGHTRaw;

    private double fio2;

    public double FiO2
    {
      get
      {
        fio2 = (FiO2Raw + FiO2Zero) * FiO2Gain / 10000.0;
        return fio2;
      }
      set { fio2 = value; }
    }

    private double tleft;

    public double TLEFT
    {
      get
      {
        tleft = (TLEFTRaw >> 3) + (TLEFTRaw & 0x07) * 0.125;
        return tleft;
      }
      set { tleft = value; }
    }

    private double trght;

    public double TRGHT
    {
      get
      {
        trght = (TRGHTRaw >> 3) + (TRGHTRaw & 0x07) * 0.125;
        return trght;
      }
      set { trght = value; }
    }

    public void AddSampleSet()
    {
      if (sampleCount < maxSampleCount)
      {
        airwayPressureStream[sampleCount] = PPROX;
        leftLungPressureStream[sampleCount] = PLEFT;
        rightLungPressureStream[sampleCount] = PRGHT;

        leftVolumeStream[sampleCount] = VLEFT;
        rightVolumeStream[sampleCount] = VRIGHT;

      }
      sampleCount++;
    }

    public void AddSampleSet(long sampleNumber)
    {
      if (sampleNumber < maxSampleCount)  // Do not overrun buffer
      {
        // Set latest sample values equal to the latest actual measurement value:
        airwayPressureStream[sampleNumber] = PPROX;     // Using the PPROX property getter also places offset and scaled measurement value into the pprox field
        leftLungPressureStream[sampleNumber] = PLEFT;
        rightLungPressureStream[sampleNumber] = PRGHT;

        long saveLastSampleNumber = lastSampleNumber;

        while ((sampleNumber - lastSampleNumber) > 1)
        {
          // Set missed sample values to the average of the two endpoint measurement values:
          for (long sample = lastSampleNumber + 1; sample < sampleNumber; ++sample)
          {
            airwayPressureStream[sample] = (airwayPressureStream[lastSampleNumber] + pprox) / 2.0;
            leftLungPressureStream[sample] = (leftLungPressureStream[lastSampleNumber] + pleft) / 2.0;
            rightLungPressureStream[sample] = (rightLungPressureStream[lastSampleNumber] + prght) / 2.0;

            ++lastSampleNumber;
          }
        }

        if (sampleNumber > pressureStreamSmoothingSampleCount)
        {
          // Smooth the pressure data streams:
          double airwayPressureSum = 0;
          double leftLungPressureSum = 0;
          double rightLungPressureSum = 0;
          for (UInt16 i = 0; i < pressureStreamSmoothingSampleCount; ++i)
          {
            airwayPressureSum += airwayPressureStream[sampleNumber - i];
            leftLungPressureSum += leftLungPressureStream[sampleNumber - i];
            rightLungPressureSum += rightLungPressureStream[sampleNumber - i];
          }
          airwayPressureStream[sampleNumber] = airwayPressureSum / pressureStreamSmoothingSampleCount;
          leftLungPressureStream[sampleNumber] = leftLungPressureSum / pressureStreamSmoothingSampleCount;
          rightLungPressureStream[sampleNumber] = rightLungPressureSum / pressureStreamSmoothingSampleCount;
        }
        else
        {
          // Prime the first stream element with the first measured values:
          // TODO: This can be improved to provide a smoother initialization
          for (UInt16 i = 0; i < pressureStreamSmoothingSampleCount; ++i)
          {
            airwayPressureStream[i] = pprox;
            leftLungPressureStream[i] = pleft;
            rightLungPressureStream[i] = prght;
          }
        }

        // Calculate volume measurements from interpolated and smoothed pressure data:
        for (long sample = saveLastSampleNumber + 1; sample <= sampleNumber; ++sample)
        {
          leftVolumeStream[sample] = CalculateLeftVolume(leftLungPressureStream[sample]);
          rightVolumeStream[sample] = CalculateRightVolume(rightLungPressureStream[sample]);
          volumeStream[sample] = leftVolumeStream[sample] + rightVolumeStream[sample];
        }

        // Calculate and smooth flow rates:

      }

      lastSampleNumber = sampleNumber;
    }

    public void ClearDataStreams()
    {
      for (long i = 0; i < maxSampleCount; ++i)
      {
        airwayPressureStream[i] = 0.0;
        leftLungPressureStream[i] = 0.0;
        rightLungPressureStream[i] = 0.0;
        leftVolumeStream[i] = 0.0;
        rightVolumeStream[i] = 0.0;
        volumeStream[i] = 0.0;
        leftFlowStream[i] = 0.0;
        rightFlowStream[i] = 0.0;
        flowStream[i] = 0.0;

      }
      lastSampleNumber = 0L;
      sampleCount = 0L;

    }

    public void LeftResistanceChanged(byte resistorValue)
    {
      if (resistorValue == 0x00)
      {
        leftAWCoefs = zeroAWCoefs;
        return;
      }

      if (ttlModel == 1)  // Single lung model (FCSL)
      {
        switch (resistorValue)
        {
          case 0x01:
            leftAWCoefs = awFCSLRp5;
            break;
          case 0x02:
            leftAWCoefs = awFCSLRp20;
            break;
          case 0x03:
            leftAWCoefs = awFCSLRp50;
            break;
          default:
            leftAWCoefs = awFCSLRp20;
            break;
        }
      }
      else if (ttlModel == 2) // Adult/Infant model (FCAI)
      {
        switch (resistorValue)
        {
          case 0x01:
            leftAWCoefs = awFCAIRp5;
            break;
          case 0x02:
            leftAWCoefs = awFCAIRp20;
            break;
          case 0x03:
            leftAWCoefs = awFCAIRp50;
            break;
          default:
            leftAWCoefs = awFCAIRp20;
            break;
        }
      }
      else if (ttlModel == 4) // Dual adult model (FCDA)
      {
        switch (resistorValue)
        {
          case 0x01:
            leftAWCoefs = awFCDARp5;
            break;
          case 0x02:
            leftAWCoefs = awFCDARp20;
            break;
          case 0x03:
            leftAWCoefs = awFCDARp50;
            break;
          default:
            leftAWCoefs = awFCDARp20;
            break;
        }
      }
    }

    public void RightResistanceChanged(byte resistorValue)
    {
      if (resistorValue == 0x00)
      {
        rightAWCoefs = zeroAWCoefs;
        return;
      }

      if (ttlModel == 1)
      {
        switch (resistorValue)  // Single lung model (FCSL)
        {
          case 0x01:
            rightAWCoefs = awFCSLRp5;
            break;
          case 0x02:
            rightAWCoefs = awFCSLRp20;
            break;
          case 0x03:
            rightAWCoefs = awFCSLRp50;
            break;
          default:
            rightAWCoefs = awFCSLRp20;
            break;
        }
      }
      else if (ttlModel == 2) // Adult/Infant model (FCAI)
      {
        switch (resistorValue)
        {
          case 0x01:
            rightAWCoefs = awFCAIRp5;
            break;
          case 0x02:
            rightAWCoefs = awFCAIRp20;
            break;
          case 0x03:
            rightAWCoefs = awFCAIRp50;
            break;
          default:
            rightAWCoefs = awFCAIRp20;
            break;
        }
      }
      else if (ttlModel == 4) // Dual adult model (FCDA)
      {
        switch (resistorValue)
        {
          case 0x01:
            rightAWCoefs = awFCDARp5;
            break;
          case 0x02:
            rightAWCoefs = awFCDARp20;
            break;
          case 0x03:
            rightAWCoefs = awFCDARp50;
            break;
          default:
            rightAWCoefs = awFCDARp20;
            break;
        }
      }
    }

  }
}
