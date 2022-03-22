<template>
  <div>
    <Toast position="top-center" group="save" />
    <Toast position="top-center" group="erro" />
    <Toast position="top-center" group="info" />
    <Sidebar id='edit' v-model:visible='storage.prop.visibleRight' position="right">
      <h5>{{ selected }}</h5>
    </Sidebar>
    <Sidebar id='new' v-model:visible='storage.prop.visibleLeft' position="left">
      <h5>{{ selected }}</h5>
    </Sidebar>
    <div class='p-d-flex p-justify-start p-align-center p-flex-column' style='height: 100vh'>
      <h1>Eventos</h1>
      <Button
        icon='pi pi-save'
        iconPos='right'
        class='p-mt-3'
        label='Adicionar'
        @click='storage.prop.visibleLeft = true'
      />
      <div>
        <DataTable :value='products'
                   responsiveLayout='scroll'
                   v-model:selection='selected'
                   selectionMode='single'
                   dataKey='id'
                   @rowSelect="storage.prop.visibleRight = true"
        >
          <Column v-for='col of columns' :field='col.field' :header='col.header' :key='col.field'></Column>
        </DataTable>
      </div>
    </div>
  </div>
</template>

<script lang='ts'>
import { defineComponent, inject, ref } from 'vue'
import { useToast } from 'primevue/usetoast'
import { useConfirm } from 'primevue/useconfirm'

export default defineComponent({
  name: 'HomeView',
  components: { useToast, useConfirm },
  setup() {
    const toast = useToast()
    const confirmDialog = useConfirm()
    const data = [
      {
        id: 1009,
        name: 'Gaming Set',
        category: 'Electronics',
        date: '25/10/2010',
        state: 'DONE'
      }
    ]
    const storage: any = inject('storage')
    const products = ref(data)
    const selected = ref()


    const columns = ref([
      { field: 'id', header: 'Código' },
      { field: 'name', header: 'Name' },
      { field: 'category', header: 'Categoria' },
      { field: 'date', header: 'Data' },
      { field: 'state', header: 'Status' }
    ])


    const saveEvent = () => {
      alert('Salvando!!!')
    }

    return {
      storage,
      selected,
      saveEvent,
      columns,
      products
    }
  }
})
</script>
