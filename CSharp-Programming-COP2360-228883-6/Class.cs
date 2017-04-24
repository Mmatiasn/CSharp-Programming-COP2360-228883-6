using System;
using System.Runtime.Serialization;

namespace CSharp_Programming_COP2360_228883_6
{
    class Class
    {
        public string ClassName { get; set; }
        public int CurrentEnrollment { get; set; }
        public int MaximumEnrollment { get; set; }
        public int AvailableSpots
        {
            get
            {
                try
                {
                    var spots = MaximumEnrollment - CurrentEnrollment;
                    if (spots >= 0)
                        return spots;
                    else
                        throw new ClassFilledException("Problem with Course: {0}\nStudents Enrolled: {1}\nMaximum Allowed: {2}\nReport halted!", ClassName);
                }
                catch (ClassFilledException)
                {

                }
                catch (Exception)
                {

                    throw;
                }
            }
            private set
            {
            }
        }
        public bool ClassFull
        {
            get
            {
                try
                {
                    return MaximumEnrollment < CurrentEnrollment;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: {0}", e);
                }
                return false;
            }
            private set { ClassFull = ClassFull; }
        }

        [Serializable]
        private class ClassFilledException : Exception
        {
            public ClassFilledException()
            {
            }

            public ClassFilledException(string message) : base(message)
            {
            }

            public ClassFilledException(string message, Exception innerException) : base(message, innerException)
            {
            }

            protected ClassFilledException(SerializationInfo info, StreamingContext context) : base(info, context)
            {
            }
        }
    }
}
