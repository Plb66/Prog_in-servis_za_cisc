<template>
  <q-page padding class="flex flex-center">
    <div class="q-pa-md full-with" style="max-width: 1500px">

      <div class="q-pa-md">
    <q-table
      title="Zahtjevi"
      :rows="rows"
      :columns="columns"
      row-key="name"
    />
  </div>
    </div>
  </q-page>
</template>


<script>
const columns = [
  {
    name: 'name',
    required: true,
    label: 'Ime korisnika',
    align: 'left',
    field: row => row.name,
    format: val => `${val}`,
    sortable: true
  },
  { name: 'Datum', align: 'center', label: 'Datum', field: 'Datum', sortable: true },
  { name: 'Vrijeme', label: 'Vrijeme', field: 'Vrijeme',  },
  { name: 'Adresa', label: 'Adresa', field: 'Adresa', sortable: true  },
  { name: 'Tip smjestaja', label: 'Tip smjestaja', field: 'Tip_smjestaja' },
  { name: 'Tip ciscenja', label: 'Tip ciscenja', field: 'Tip_ciscenja' },
]

const rows = [
{
    name: 'ivan ivic',
    Datum: '21/04/23',
    Vrijeme: '12:00',
    Adresa: 'Bana jelacica 12',
    Tip_smjestaja: 'apartman',
    Tip_ciscenja: 'generalka',

  },
]

export default {
  setup () {
    return {
      columns,
      rows
    }
  }
}
</script>
