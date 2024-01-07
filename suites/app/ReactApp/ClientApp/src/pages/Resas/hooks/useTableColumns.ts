import { ITableColumnContent } from 'components/molecules/DataTable/types/ITableColumnContent'

export default function useTableColumns(): ITableColumnContent[] {
  const tableColumns: ITableColumnContent[] = [
    { columnKey: 'id', label: 'id' },
    { columnKey: 'name', label: 'name' },
    { columnKey: 'category', label: 'category' },
    { columnKey: 'label', label: 'label' }
  ]
  return tableColumns
}
