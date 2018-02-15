
array=("union" "except" "intersect" "xor")
a=$1
b=$2

i=0
for e in ${array[@]}; do
    echo "array[$i] = ${e}"
    echo "${a}"
    echo "${b}"
    ../SetOperator.exe $e $a $b > "${e}.txt"
    let i++
done

../SetOperator.exe "except" $b $a > "except_rev.txt"
args=$*
echo "sc.sh ${args}" > log.txt
echo "except is ${a} - ${b}" >> log.txt
echo "except_rev is ${b} - ${a}" >> log.txt

