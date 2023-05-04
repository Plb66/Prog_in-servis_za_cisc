<template>
  <q-layout view="hHh Lpr fFf"> <!-- Be sure to play with the Layout demo on docs -->
    <q-page-container>
      <div class="bg-image">
      <!-- This is where pages get injected -->
      <router-view />
      </div>
    </q-page-container>
  </q-layout>
</template>


<style>
.bg-image {
  background-image: url(https://i.imgur.com/as0Qxif.png) ;

}
</style>

