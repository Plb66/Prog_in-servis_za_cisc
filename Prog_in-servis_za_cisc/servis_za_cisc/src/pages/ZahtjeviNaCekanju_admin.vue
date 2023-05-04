<template>
  <q-page padding class="flex flex-center">
  <div class="q-pa-md">
<q-card>
    <q-table
      flat bordered
      ref="tableRef"
      title="Zahtjevi na cekanju"
      :rows="rows"
      :columns="columns"
      row-key="name"
      selection="multiple"
      v-model:selected="selected"
      @selection="handleSelection"
    >
      <template v-slot:header-selection="scope">
        <q-checkbox v-model="scope.selected" />
      </template>

      <template v-slot:body-selection="scope">
        <q-checkbox :model-value="scope.selected" @update:model-value="(val, evt) => { Object.getOwnPropertyDescriptor(scope, 'selected').set(val, evt) }" />
      </template>
    </q-table>
    <div class="q-gutter-sm">
      <div class="q-pa-sm">
        <q-btn align: between unelevated color="green"   label="Potvrdi" text-align="left" class="full-width"  />
      </div>
      <div class="q-pa-sm">
        <q-btn align: between unelevated color="red"   label="Odbi" text-align="right" class="full-width" />
      </div>
    </div>
  </q-card>
  </div>
</q-page>
</template>




<script>
import { ref, toRaw, nextTick } from 'vue'

const columns = [
  {
    name: 'name',
    required: true,
    label: 'Ime klijenta',
    align: 'left',
    field: row => row.name,
    format: val => `${ val }`,
    sortable: true
  },
  { name: 'Datum', align: 'center', label: 'Datum', field: 'Datum', sortable: true },
  { name: 'Vrijeme', label: 'Vrijeme', field: 'Vrijeme',  },
  { name: 'Adresa', label: 'Adresa', field: 'Adresa', sortable: true  },
  { name: 'Tip smjestaja', label: 'Tip smjestaja', field: 'Tip_smjestaja' },
  { name: 'Tip ciscenja', label: 'Tip ciscenja', field: 'Tip_ciscenja' },
]

const rows = [
 {name: 'ivan ivic',
    Datum: '21/04/23',
    Vrijeme: '12:00',
    Adresa: 'Bana jelacica 12',
    Tip_smjestaja: 'apartman',
    Tip_ciscenja: 'generalka',}
]

export default {
  setup () {
    const tableRef = ref()
    const selected = ref([])
    let storedSelectedRow

    return {
      tableRef,
      selected,
      columns,
      rows,

      handleSelection ({ rows, added, evt }) {
        // ignore selection change from header of not from a direct click event
        if (rows.length !== 1 || evt === void 0) {
          return
        }

        const oldSelectedRow = storedSelectedRow
        const [newSelectedRow] = rows
        const { ctrlKey, shiftKey } = evt

        if (shiftKey !== true) {
          storedSelectedRow = newSelectedRow
        }

        // wait for the default selection to be performed
        nextTick(() => {
          if (shiftKey === true) {
            const tableRows = tableRef.value.filteredSortedRows
            let firstIndex = tableRows.indexOf(oldSelectedRow)
            let lastIndex = tableRows.indexOf(newSelectedRow)

            if (firstIndex < 0) {
              firstIndex = 0
            }

            if (firstIndex > lastIndex) {
              [ firstIndex, lastIndex ] = [ lastIndex, firstIndex ]
            }

            const rangeRows = tableRows.slice(firstIndex, lastIndex + 1)
            // we need the original row object so we can match them against the rows in range
            const selectedRows = selected.value.map(toRaw)

            selected.value = added === true
              ? selectedRows.concat(rangeRows.filter(row => selectedRows.includes(row) === false))
              : selectedRows.filter(row => rangeRows.includes(row) === false)
          }
          else if (ctrlKey !== true && added === true) {
            selected.value = [newSelectedRow]
          }
        })
      }
    }
  }
}
</script>
