<template>
    <v-card class="mb-2">
        <v-card-title primary-title>
            <div>
                <h3 class="headline mb-0">
                    {{data.EMPLOYEE_NAME}}
                </h3>
                <div class="grey--text">{{data.EMPLOYEE_SALARY}}</div>
            </div>
        </v-card-title>
    </v-card>
</template>

<script>
export default {
    props: ['data']
}
</script>