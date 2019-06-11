<template>
    <v-card class="mb-2">
        <v-card-title primary-title>
            <div>
                <router-link :to="'/department/employee/' + data.DEPARTMENT_ID">
                    <h3 class="headline mb-0">
                        {{data.DEPARTMENT_NAME}}
                    </h3>
                </router-link>
                <div class="grey--text">{{data.DEPARTMENT_HEAD}}</div>
            </div>
        </v-card-title>
    </v-card>
</template>

<script>
export default {
    props: ['data']
}
</script>