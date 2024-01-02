class Queue<T> {

    private array: T[] = []

    push(item: T){
        this.array.push(item)
    }

    pop(): T | undefined {
        return this.array.shift();
    }
}