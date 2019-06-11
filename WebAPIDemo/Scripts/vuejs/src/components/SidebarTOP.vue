<template>
  <v-toolbar>
    <v-toolbar-items>
      <v-btn flat
      v-for="item in data" :key="item.title"
      >
      <v-icon right dark>{{item.icon}}</v-icon>
      {{ item.title }}
      </v-btn>
    </v-toolbar-items>
  </v-toolbar>
</template>

<script>
export default {
    props: ['data'],
}
</script>