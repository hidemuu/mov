import { ITableColumn } from '../../../components/molecules/DataTable/types/ITableColumn'

export default function useTableColumns(): ITableColumn[] {
  const tableColumns: ITableColumn[] = [
    { columnKey: 'id', label: 'id' },
    { columnKey: 'name', label: 'name' },
    { columnKey: 'category', label: 'category' },
    { columnKey: 'label', label: 'label' }
  ]
  return tableColumns
}
