<template>
    <!--系统配置-->
    <el-table v-loading="loading" class="mgt w100" stripe :data="aliData" border v-if="showType == 0">
        <el-table-column prop="label" width="300" label="标题" align="center"></el-table-column>
        <el-table-column prop="mark" width="300" label="说明" align="center"></el-table-column>
        <el-table-column label="标题" align="center">
            <template #default="scope">
                <el-input v-if="scope.row.key == 'bucketName'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'endpoint'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'accessKeyId'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'accessKeySecret'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'staticUrl'" v-model="scope.row.value"></el-input>
            </template>
        </el-table-column>
    </el-table>

    <el-table v-loading="loading" class="mgt w100" stripe :data="taskIntegralSetting" border v-if="showType == 1">
        <el-table-column prop="label" width="300" label="标题" align="center"></el-table-column>
        <el-table-column prop="mark" width="300" label="说明" align="center"></el-table-column>
        <el-table-column label="标题" align="center">
            <template #default="scope">
                <el-input v-if="scope.row.key == 'buyProductIntegral'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'cardRepayIntegral'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'loanRepayIntegral'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'invitationIntegral'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'cardRepayIntegralCountLimit'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'loanRepayIntegralCountLimit'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'taskCreditValue'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'taskCountLimit'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'weekTaskCreditValue'" v-model="scope.row.value"></el-input>
                <el-input v-if="scope.row.key == 'weekTaskCountLimit'" v-model="scope.row.value"></el-input>
            </template>
        </el-table-column>
    </el-table>




    <div class="mgt w100 flex-row-end">
        <el-button type="primary" @click="save">保存</el-button>
    </div>
</template>

<script>
    export default {
        beforeRouteEnter(to,from,next) {
            next(vm => {
                vm.loadShowType();
            });
        },
        name: "sys_config",
        data() {
            return {
                // 显示类型 0 阿里配置 1 积分配置
                showType: 0,

                loading : false,
                aliData: [
                    {
                        label: 'BucketName',
                        mark: '',
                        key: 'bucketName',
                        value: ''
                    },
                    {
                        label: 'Endpoint',
                        mark: '',
                        key: 'endpoint',
                        value: ''
                    },
                    {
                        label: 'AccessKeyId',
                        mark: '',
                        key: 'accessKeyId',
                        value: ''
                    },
                    {
                        label: 'AccessKeySecret',
                        mark: '',
                        key: 'accessKeySecret',
                        value: ''
                    },
                    {
                        label: 'StaticUrl',
                        mark: '',
                        key: 'staticUrl',
                        value: ''
                    }
                ],
                taskIntegralSetting: [
                    {
                        label: '购买产品积分',
                        mark: '',
                        key: 'buyProductIntegral',
                        value: ''
                    },
                    {
                        label: '信用卡代还积分',
                        mark: '',
                        key: 'cardRepayIntegral',
                        value: ''
                    },
                    {
                        label: '贷款代还积分',
                        mark: '',
                        key: 'loanRepayIntegral',
                        value: ''
                    },
                    {
                        label: '邀请用户积分',
                        mark: '',
                        key: 'invitationIntegral',
                        value: ''
                    },
                    {
                        label: '信用卡代还积分次数限制',
                        mark: '',
                        key: 'cardRepayIntegralCountLimit',
                        value: ''
                    },
                    {
                        label: '贷款代还积分次数限制',
                        mark: '',
                        key: 'loanRepayIntegralCountLimit',
                        value: ''
                    },
                    {
                        label: '信用卡代还信用值',
                        mark: '',
                        key: 'taskCreditValue',
                        value: ''
                    },
                    {
                        label: '信用卡代还信用值每日次数限制',
                        mark: '',
                        key: 'taskCountLimit',
                        value: ''
                    },
                    {
                        label: '贷款代还信用值',
                        mark: '',
                        key: 'weekTaskCreditValue',
                        value: ''
                    },
                    {
                        label: '贷款代还信用值每周次数限制',
                        mark: '',
                        key: 'weekTaskCountLimit',
                        value: ''
                    },
                ]
            }
        },
        methods: {
            loadShowType() {
                let path = this.$route.path;
                if (path.indexOf('/aliConfig') != -1) {
                    this.showType = 0;
                } else if (path.indexOf('/taskIntegral') != -1) {
                    this.showType = 1;
                }

                this.loadData();
            },
            save() {
                switch (this.showType) {
                    case 0:
                        this.saveAliData();
                        break;
                        case 1:
                            this.saveTaskIntegral();
                            break;
                }
            },
            loadData() {
                switch (this.showType) {
                    case 0:
                        this.getAliData();
                        break;
                    case 1:
                        this.getTaskIntegral();
                        break;
                }
            },
            getAliData() {
                this.loading = true;
                this.$Http.get('AdminSetting/GetAlibabaCloudSetting').then(res=>{
                    for (let index in this.aliData) {
                        let item = this.aliData[index];
                        item.value = res.data.data[item.key];
                    }
                    this.loading = false;
                }).catch(res=>{
                    this.loading = false;
                    this.$message.error(res.data.message);
                })
            },
            saveAliData() {
                this.loading = true;
                let param = {};
                for (let index in this.aliData) {
                    let item = this.aliData[index];
                    if (this.$ObjectUtil.isEmpty(item.value) && item.value != '') {
                        continue;
                    }
                    if (item.key == 'timeZone') {
                        let regex = /^(-)?\d+$/g;
                        if (!regex.test(item.value)) {
                            this.$message.error('请输入:正负整数');
                            return;
                        }
                    }
                    param[item.key] = item.value;
                }
                this.$Http.post('AdminSetting/AlibabaCloudSetting',param).then(()=>{
                    this.loadData();
                }).catch(res=>{
                    this.loading = false;
                    this.$message.error(res.data.message);
                })
            },
            getTaskIntegral() {
                this.loading = true;
                this.$Http.get('AdminSetting/GetTaskIntegralSetting').then(res=>{
                    for (let index in this.taskIntegralSetting) {
                        let item = this.taskIntegralSetting[index];
                        item.value = res.data.data[item.key];
                    }
                    this.loading = false;
                }).catch(res=>{
                    this.loading = false;
                    this.$message.error(res.data.message);
                })
            },
            saveTaskIntegral() {
                this.loading = true;
                let param = {};
                for (let index in this.taskIntegralSetting) {
                    let item = this.taskIntegralSetting[index];
                    if (this.$ObjectUtil.isEmpty(item.value) && item.value != '') {
                        continue;
                    }
                    if (item.key == 'timeZone') {
                        let regex = /^(-)?\d+$/g;
                        if (!regex.test(item.value)) {
                            this.$message.error('请输入:正负整数');
                            return;
                        }
                    }
                    param[item.key] = item.value;
                }
                this.$Http.post('AdminSetting/TaskIntegralSetting',param).then(()=>{
                    this.loadData();
                }).catch(res=>{
                    this.loading = false;
                    this.$message.error(res.data.message);
                })
            },
        }
    }
</script>

<style scoped>
    @import "/src/commcss/flex.css";
    @import "/src/commcss/background.css";
</style>