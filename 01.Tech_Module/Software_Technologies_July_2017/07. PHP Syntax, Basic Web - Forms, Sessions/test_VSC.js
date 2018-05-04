function solve(arr) {
    let num1 = Number(arr[0]);
    let num2 = Number(arr[1]);

    let result = multiply(num1, num2);

    console.log(result)

    function multiply(num1, num2) {
        return num1 * num2;
    }
}
let input = ['2', '3'];
solve(input);
