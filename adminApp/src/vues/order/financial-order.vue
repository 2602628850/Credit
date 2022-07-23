<template>
    <!--理财订单-->
    <el-space wrap class="w100 font-size-search" id="search-info">
        <div class="search-input flex-row-start">
            <div>用户名</div>
            <el-input v-model="UserKey" class="search-flex-sub"></el-input>
        </div>
        <div class="search-input flex-row-start">
            <div>审核状态</div>
            <el-select v-model="Status" class="search-flex-sub">
                <el-option :value="-1" label="全部"></el-option>
                <el-option v-for="item in audits" :value="item.value" :key="item.value" :label="item.title"></el-option>
            </el-select>
        </div>
        <div class="search-input flex-row-start">
            <div>首出审核状态</div>
            <el-select v-model="SoldStatus" class="search-flex-sub">
                <el-option :value="-1" label="全部"></el-option>
                <el-option v-for="item in audits" :value="item.value" :key="item.value" :label="item.title"></el-option>
            </el-select>
        </div>
        <div class="search-input flex-row-start">
            <div>产品名称</div>
            <el-input class="search-flex-sub" v-model="ProductKey"></el-input>
        </div>
        <div class="search-input flex-row-start">
            <div>是否结束</div>
            <el-select v-model="IsSold" class="search-flex-sub">
                <el-option :value="-1" label="全部"></el-option>
                <el-option :value="true" label="已结束"></el-option>
                <el-option :value="false" label="未结束"></el-option>
            </el-select>
        </div>
        <div class="search-input flex-row-start">
            <div>开始时间</div>
            <el-date-picker class="search-flex-sub" v-model="StartTime">

            </el-date-picker>
        </div>
        <div class="search-input flex-row-start">
            <div>结束时间</div>
            <el-date-picker class="search-flex-sub" v-model="EndTime">

            </el-date-picker>
        </div>
    </el-space>

    <div class="w100 flex-row-between mgt" id="search-button">
        <el-button type="primary" @click="loadData(1)">查询</el-button>
    </div>

    <el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
        <el-table-column prop="id" label="ID" width="200" align="center"></el-table-column>
        <el-table-column prop="productName" label="产品名称" width="200" align="center"></el-table-column>
        <el-table-column prop="" label="用户" width="200" align="center">
            <template #default="scope">
                {{scope.row.username}}({{scope.row.nickname}})
            </template>
        </el-table-column>
        <el-table-column prop="unitCount" label="数量" width="200" align="center"></el-table-column>
        <el-table-column prop="price" label="单价" width="200" align="center"></el-table-column>
        <el-table-column prop="totalAmount" label="总额" width="200" align="center"></el-table-column>
        <el-table-column prop="dailyRate" label="日收益" width="200" align="center"></el-table-column>
        <el-table-column prop="buyDate" label="购买日期" width="200" align="center"></el-table-column>
        <el-table-column prop="cycle" label="周期" width="200" align="center"></el-table-column>
        <el-table-column prop="settledCount" label="结算次数" width="200" align="center"></el-table-column>
        <el-table-column prop="nextSettledDate" label="下次结算时间" width="200" align="center"></el-table-column>
        <el-table-column prop="isSold" label="状态" width="100" align="center">
            <template #default="scope">
                <div :style="scope.row.isSold ? {color: 'darkred'} : {color: 'darkgreen'}">{{scope.row.isSold ? '已售卖' : '未售卖'}}</div>
            </template>
        </el-table-column>
        <el-table-column prop="statusText" label="审核状态" width="200" align="center"></el-table-column>
        <el-table-column prop="auditText" label="审核描述" width="200" align="center"></el-table-column>

        <el-table-column prop="soldStatusText" label="售出审核状态" width="200"   align="center"></el-table-column>
        <el-table-column prop="soldAuditText" label="售出审核描述" width="200"   align="center"></el-table-column>

        <el-table-column prop="todateTime" label="购买时间" width="200" align="center"></el-table-column>

        <el-table-column prop="" label="操作" align="center" width="130" fixed="right">
            <template #default="scope">
                <el-space>
                    <el-button v-if="scope.row.status != 20 && scope.row.status != 30 && scope.row.soldStatus != 20 && scope.row.soldStatus != 30" type="danger" size="small" plain @click="audit(scope.row)">审核</el-button>
                </el-space>
            </template>
        </el-table-column>
    </el-table>
    <div class="w100 flex-row-end mgt" id="page">
        <el-pagination background layout="prev, pager, next" :total="total" :page-size="pageSize"/>
    </div>



    <el-dialog v-model="auditStatus" :width="'600px'">
        <el-space direction="vertical" v-loading="auditLoading">
            <el-space>
                <div class="in-title">审核状态</div>
                <el-select class="in-input" v-model="auditItem.status">
                    <el-option :value="20" label="通过"></el-option>
                    <el-option :value="30" label="未通过"></el-option>
                </el-select>
            </el-space>
            <el-space>
                <div class="in-title">描述</div>
                <el-input class="in-input" type="textarea" autosize v-model="auditItem.auditText"></el-input>
            </el-space>
            <el-space>
                <el-button @click="doAudit">提交</el-button>
            </el-space>
        </el-space>
    </el-dialog>
</template>

<script>

    export default {
        name: "financial-order",
        beforeRouteEnter(to, from, next) {
            next(vm => {
                vm.getTableHeight();
                vm.loadData(1)
            })
        },
        data() {
            return {
                audits: this.$ObjectUtil.getAuditStatusEnums(),

                UserKey: '',
                Status: -1,
                SoldStatus: -1,
                ProductKey: '',
                IsSold: -1,
                StartTime: '',
                EndTime: '',

                contentHeight: '500px',

                pageIndex: 1,
                pageSize: 20,
                total: 0,
                tableData: [],
                loading: false,

                auditStatus: false,
                auditLoading:false,
                auditItem: {},
                auditIsSold: false,
            }
        },
        methods: {
            doAudit() {
                this.auditLoading = true;
                if (this.auditIsSold) {
                    // 售卖
                    this.$Http.post('AdminOrder/AuditSoldOrder',this.auditItem).then(()=>{
                        this.auditStatus = false;
                        this.loadData();
                    }).catch(res=>{
                        this.$message.error(res.data.message);
                        this.auditLoading = false;
                    })
                } else {
                    // 购买
                    this.$Http.post('AdminOrder/AuditBuyOrder',this.auditItem).then(()=>{
                        this.auditStatus = false;
                        this.loadData();
                    }).catch(res=>{
                        this.$message.error(res.data.message);
                        this.auditLoading = false;
                    })
                }
            },
            audit(item) {
                this.auditItem.id = item.id;
                this.auditIsSold = item.isSold;
                this.auditStatus = true;
                this.auditLoading = false;
            },
            loadData(page) {
                let param = {};
                if (!this.UserKey) {
                    param.UserKey = this.UserKey;
                }
                if (this.Status != -1) {
                    param.Status = this.Status;
                }
                if (this.SoldStatus != -1) {
                    param.SoldStatus = this.SoldStatus;
                }
                if (!this.ProductKey) {
                    param.ProductKey = this.ProductKey;
                }
                if (this.IsSold != -1) {
                    param.IsSold = this.IsSold;
                }
                if (this.StartTime) {
                    param.StartTime = this.StartTime.getTime();
                }
                if (this.EndTime) {
                    param.EndTime = this.EndTime.getTime();
                }

                if (!page) {
                    this.pageIndex = page;
                }
                param.pageIndex = this.pageIndex;
                param.pageSize = this.pageSize;
                this.loading = true;
                this.$Http.get('AdminOrder/GetOrderPagedList', {params: param}).then(res => {
                    this.tableData = res.data.data.items;
                    this.total = parseInt(res.data.data.totalCount);
                    this.loading = false;
                }).catch((res) => {
                    this.$message.error(res.data.data.message);
                    this.loading = false;
                })
            },

            getTableHeight() {
                this.$nextTick(() => {
                    let searchInfo = document.getElementById('search-info');
                    let searchButton = document.getElementById('search-button');
                    let page = document.getElementById('page');

                    let height = searchInfo.offsetHeight + searchButton.offsetHeight + page.offsetHeight + 24 + 'px';

                    this.contentHeight = 'calc(100% - ' + height + ')'
                })
            },
        }
    }
</script>

<style scoped>
    @import "/src/commcss/flex.css";
    @import "/src/commcss/background.css";
</style>