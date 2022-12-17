# for i in `find /home/database -name "*.sql" | sort --version-sort`; do myslq -udocker -pdocker rest_with_asp_net_udemy < $i; done;
for i in `find /home/database -name "*.sql" | sort --version-sort`; do sqlcmd -U sa -P Losk0707 -i $i < $i; done;
