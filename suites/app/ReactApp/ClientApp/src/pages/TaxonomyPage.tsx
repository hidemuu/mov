import * as React from 'react'
import { PageHeader } from '../components/organisms/PageHeader'
import { TaxonomyExplorer } from './Taxonomy/TaxonomyExplorer'

export const TaxonomyPage: React.FunctionComponent = () => {
  return (
    <>
      <PageHeader
        title={'Taxonomy Explorer'}
        description={
          'Use this taxonomy explorer to see all term groups, term sets and terms available'
        }
      ></PageHeader>
      <TaxonomyExplorer />
    </>
  )
}
