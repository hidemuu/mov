import { TableColumn } from "../models/TableColumn";

export default function useTableColumns() : TableColumn[] {
    const tableColumns : TableColumn[] = [
        { columnKey: 'id', label: 'id' },
        { columnKey: 'name', label: 'name' },
        { columnKey: 'category', label: 'category' },
        { columnKey: 'label', label: 'label' },
    ];
    return tableColumns;
}