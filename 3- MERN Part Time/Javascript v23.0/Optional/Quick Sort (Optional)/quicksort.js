function partition(arr, low, high) {
    let pivot = arr[Math.floor((low + high) / 2)];
    let i = low;
    let j = high;

    while (i <= j) {
        while (arr[i] < pivot) {
            i++;
        }
        while (arr[j] > pivot) {
            j--;
        }
        if (i <= j) {
            [arr[i], arr[j]] = [arr[j], arr[i]]; 
            i++;
            j--;
        }
    }
    return i;
}

function quickSort(arr, low, high) {
    if (arr.length > 1) {
        let index = partition(arr, low, high);

        if (low < index - 1) {
            quickSort(arr, low, index - 1);
        }
        if (index < high) {
            quickSort(arr, index, high);
        }
    }
    return arr;
}

let arr = [85, 24, 63, 45, 17, 31, 96, 50];
quickSort(arr, 0, arr.length - 1);