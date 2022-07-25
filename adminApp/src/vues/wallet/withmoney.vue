<template>
	<!--信用等级管理-->
	<el-space wrap class="w100" id="search-info">
		<el-space class="search-input400">
			<div class="search-input flex-row-start">
           <div>开始申请时间</div>
            <el-date-picker class="search-flex-sub" v-model="StartTime">

            </el-date-picker>
        </div>
        <div class="search-input flex-row-start">
      <div>结束申请时间</div>
            <el-date-picker class="search-flex-sub" v-model="EndTime">

            </el-date-picker>
        </div>
		</el-space>
	</el-space>
	<div class="w100 mgt flex-row-between" id="search-button">
		<el-button type="primary" @click="loadData(1)">查询</el-button>
	</div>
	<el-table v-loading="loading" class="mgt w100" stripe :data="tableData" style="flex: 1" border :height="contentHeight">
		<el-table-column prop="username" label="申请人" width="200" align="center"></el-table-column>
  <el-table-column prop="createAt" label="申请时间" width="200" align="center">
			<template #default="scope">
				{{ getTime(scope.row.createAt) }}
			</template>
      </el-table-column>
  <el-table-column prop="amount" label="申请金额" width="200" align="center"></el-table-column>
		<el-table-column prop="auditStatus" label="审核状态" width="200" align="center">
			<template #default="scope">
				{{ scope.row.auditStatus=="0"?"默认":scope.row.auditStatus=="10"?"处理中":scope.row.auditStatus=="20"?"成功":"失败"}}
			</template>
		</el-table-column>
    <el-table-column prop="auditUsername" label="审核人" width="200" align="center"></el-table-column>
     <el-table-column prop="paymentInfoName" label="三方接口" width="200" align="center"></el-table-column>
     <el-table-column prop="payeeBankNo" label="收款卡号" width="200" align="center"></el-table-column>
       <el-table-column prop="auditAt" label="审核时间" width="200" align="center">
			<template #default="scope">
				{{ getTime(scope.row.auditAt) }}
			</template>
		</el-table-column>
     <el-table-column prop="" label="操作" align="center" width="130" fixed="right">
            <template #default="scope">
                <el-space>
                    <el-button v-if="scope.row.auditStatus != 20 && scope.row.auditStatus != 30" type="danger" size="small" plain @click="audit(scope.row)">审核</el-button>
                </el-space>
            </template>
        </el-table-column>
	</el-table>
	<!--	</div>-->
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
		name: "bank-manager",
		beforeRouteEnter(to, from, next) {
			next(vm => {
				vm.getTableHeight();
				vm.loadData(1)
			})
		},
		data() {
			return {
			//: 'http://localhost:8003/v1/Upload/Image',
			StartTime: '',
        EndTime: '',
				contentHeight: '0px',
				pageIndex: 1,
				pageSize: 20,
				total: 0,
				tableData: [],
				loading: false,
				windowStatus: false,
				auditItem: {},
				windowSaving: false,
			auditStatus: false,
			}
		},
	components: {
  },
		methods: {

			delItem(item) {
				this.$msgbox({
					title: '提示',
					message: '确认删除' + item.levelName + '?',
					showCancelButton: true,
					beforeClose: (action,instance,done) => {
						if (action == 'confirm') {
							this.loading = true;
							this.$Http.post('AdminBank/BankDelete', {id: item.id}).then(() => {
								this.loadData();
								done();
							}).catch(res => {
								this.$message.error(res.data.message);
								this.loading = false;
							})
						} else {
							done();
						}
					}
				})

			},
			getTime(time) {
				return this.$DateUtil.formatUnix(time / 1000);
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
			doAudit() {
                this.auditLoading = true;
                    this.$Http.post('AdminWallet/MoneyApplyAudit',this.auditItem).then(()=>{
                        this.auditStatus = false;
                        this.loadData();
                    }).catch(res=>{
                        this.$message.error(res.data.message);
                        this.auditLoading = false;
                    })			
            },
          audit(item) {
                this.auditItem.MoneyApplyId = item.applyId;
                this.auditStatus = true;
                this.auditLoading = false;
            },
			loadData(page) {
				let param = {};
				if (this.StartTime) {
                    param.StartTime = this.StartTime.getTime();
                }
                if (this.EndTime) {
                    param.EndTime = this.EndTime.getTime();
                }
				if (page) {
					this.pageIndex = page;
				}
				param.pageIndex = this.pageIndex;
				param.pageSize = this.pageSize;
				this.loading = true;
				this.$Http.get('AdminWallet/GetWithdrawalApplyPagedList', {params: param}).then(res => {
					this.tableData = res.data.data.items;
					this.total = parseInt(res.data.data.totalCount);
					this.loading = false;
				}).catch((res) => {
					this.$message.error(res.data.data.message);
					this.loading = false;
				})
			}
		}
	}
</script>

<style scoped>
	@import "/src/commcss/flex.css";
	@import "/src/commcss/background.css";

</style>