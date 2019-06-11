<template>
    <div>
        <toolbar></toolbar>
        <router-view :key="$route.fullPath"></router-view>
        <app-footer></app-footer>
    </div>
</template>

<script>
import toolbar from '../components/Toolbar'
import AppFooter from '../components/AppFooter'
import Department from '../pages/Department'

export default {
    components: {toolbar, AppFooter, Department}
}
</script>

<style scoped>

</style>
