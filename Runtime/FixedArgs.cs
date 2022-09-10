using System;
namespace FixedMath{

    public struct FixedArgs{
        public int value;
        //multipler = 放大的倍数
        public uint multipler;
        public FixedArgs(int value, uint multipler){
            this.value = value;
            this.multipler = multipler;
        }
    
        public static FixedArgs PI = new FixedArgs(31416,10000) ;
    
        public static bool operator > (FixedArgs a, FixedArgs b){
            if(a.multipler == b.multipler) return a.value > b.value;
            else 
                throw new System.Exception("角度倍数不同");
        }
        public static bool operator < (FixedArgs a, FixedArgs b){
            if(a.multipler == b.multipler) return a.value < b.value;
            else 
                throw new System.Exception("角度倍数不同");
        }
        public static bool operator == (FixedArgs a, FixedArgs b){
            if(a.multipler == b.multipler) return a.value == b.value;
            else 
                throw new System.Exception("角度倍数不同");
        }
        public static bool operator != (FixedArgs a, FixedArgs b){
            if(a.multipler == b.multipler) return a.value != b.value;
            else 
                throw new System.Exception("角度倍数不同");
        } 
        public static bool operator <= (FixedArgs a, FixedArgs b){
            if(a.multipler == b.multipler) return a.value <= b.value;
            else 
                throw new System.Exception("角度倍数不同");
        } 
        public static bool operator >= (FixedArgs a, FixedArgs b){
            if(a.multipler == b.multipler) return a.value >= b.value;
            else 
                throw new System.Exception("角度倍数不同");
        }    
        
        public override int GetHashCode(){
            return value.GetHashCode();
        }

        public override bool Equals(object obj){
            return obj is FixedArgs args 
                    && value == args.value
                    && multipler == args.multipler;

        }
        public override string ToString(){
            return $"value: {value} multipler: {multipler}";
        }
        
        
        
        /// <summary>
        /// 转化为视图层的角度，不可再参与运算
        /// </summary>
        /// <returns></returns>
        public int ConvertToViewAngle(){
            float radians = ConvertToFloat();
            return (int)Math.Round(radians / Math.PI * 180);
        }
        public float ConvertToFloat(){
            return value *1.0f/multipler;
        }
    
    
    
    
    }

}